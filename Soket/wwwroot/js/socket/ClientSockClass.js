class ClientSock
{

    constructor(host, wsLocation)
    {
        this.connetionId = "";


        /* Use js/utils/httpUtil.js */
        this.sockUrl = GetSocketUrl(host, wsLocation); //(location.host, "WsA");

        /* Use lib/socket/WebSocketManger.js*/
        this.connection = new WebSocketManager(this.sockUrl);

        this.connection.onConnected = (id) => {
            this._onConnected(id);
        };

        // optional.
        // called when the connection to the server has been lost.
        this.connection.onDisconnected = () => {
            this._onDisconnected();
        };

        // optional.
        // called when some plain-text message has been received.
        this.connection.onMessage = (text) => {
            this._onMessage(text);
        };

        // here we register a method with two arguments that can be called by the server.
        this.connection.methods.receiveMessage = (userid, text) => {
            this._onClientMessage(userid, text);
        };

        // Get Ip Action
        this.connection.methods.GetIP = (data) => {
            return data;
        }

    }

    _onConnected(id)
    {
        //console.log("-> You are now connected! Connection ID: " + id);

        // Set connetion ID
        this.connetionId = id;

        // Set Ip infomation
        this.connection.invoke('GetIP', 'string', getIp(), (data, error) => {
            if (data) this._onIP(data);
            if (error) console.error("The server's errored: " + error);
        });

        // https://geoiplookup.io/api
        $.getJSON('https://json.geoiplookup.io/', function (data) {
            console.log(data);
        });

        var x = ip_local();
        console.log(x);
    }

    _onIP(data)
    {
        this._onMessage(data);
    }

    _onDisconnected()
    {
        console.log("-> Disconnected!");
    }

    _onMessage(text)
    {
        var obj;
        try {
            // Try parse
            obj = JSON.parse(text);
        }
        catch (e) {
            return;
        }

        this._MessageTypeFinder(obj);
    }

    _MessageTypeFinder(obj)
    {
        var type = obj["Type"];

        switch (type)
        {
            case "Info":
                this._InfoMessageFinder(obj);
                break;
            default:
                console.log(obj);
                break;
        }
    }

    _InfoMessageFinder(obj)
    {
        var subType = obj["SubType"];

        switch (subType) {
            case "SocketID":
                new MessageController().UpdateConnectionId(obj["ServerTime"], obj["Data"]);
                break;
            case "ClientIp":
                new MessageController().UpdateConnectionIp(obj["ServerTime"], obj["Data"]);
                break;
            default:
                console.log(obj);
                break;
        }
    }
    
    _onClientMessage(userid, text)
    {
        console.log(userid + " said: " + text);
    }
    
    Start()
    {
        this.connection.connect();
    }

}