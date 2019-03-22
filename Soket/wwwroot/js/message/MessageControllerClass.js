class MessageController
{
    constructor()
    {
        this.messageBox = $('#chat-body');
    }

    UpdateConnectionId(time, data)
    {
        // Convert Date
        var date = new Date(time);
        var strDate = NomalyformatDate(date);

        var str =
             '<li>'
            + '<div class="chat-container">'
            + ' <img src="https://icons.iconarchive.com/icons/cornmanthe3rd/metronome/512/System-network-icon.png" class="img-circle">'
            + ' <p>Get Connetion ID : ' + data + '</p>'
            + '<span class="time-right">' + strDate + '</span>'
            + '</div>'
            + '</li>'

        this.messageBox.append(str);
    }

    UpdateConnectionIp(time, data) {
        // Convert Date
        var date = new Date(time);
        var strDate = NomalyformatDate(date);

        var str =
            '<li>'
            + '<div class="chat-container">'
            + ' <img src="https://icons.iconarchive.com/icons/cornmanthe3rd/metronome/512/System-network-icon.png" class="img-circle">'
            + ' <p>Your IP : ' + data + '</p>'
            + '<span class="time-right">' + strDate + '</span>'
            + '</div>'
            + '</li>'

        this.messageBox.append(str);
    }
}