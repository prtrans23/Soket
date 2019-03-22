

function Main()
{
    var hosturl = location.host;
    var wsLoc = "WsA";

    var socket = new ClientSock(hosturl, wsLoc);
    socket.Start();
}



window.onload = (event) => {
    Main();
};