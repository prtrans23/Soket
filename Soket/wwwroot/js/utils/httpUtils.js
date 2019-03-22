// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function GetSocketScheme()
{
    return (window.location.protocol == "https:") ? "wss" : "ws";
}

function GetProtocolScheme()
{
    return window.location.protocol;
}

function GetHost()
{
    return location.host;
}

function GetSocketUrl(host, wsLocation)
{
    return (GetSocketScheme() + "://" + host + "/" + wsLocation)
}

function ip_local() {
    var ip = false;
    var str;
    window.RTCPeerConnection = window.RTCPeerConnection || window.mozRTCPeerConnection || window.webkitRTCPeerConnection || false;

    if (window.RTCPeerConnection) {
        ip = new Array();
        var pc = new RTCPeerConnection({ iceServers: [] }), noop = function () { };
        pc.createDataChannel('');
        pc.createOffer(pc.setLocalDescription.bind(pc), noop);

        pc.onicecandidate = function (event) {
            if (event && event.candidate && event.candidate.candidate) {
                var s = event.candidate.candidate.split('\n');
                var p = s[0].split(' ')[4];
                var str = "" + p;

                // 왠지모르겠지만 함수 바깥에서 검색이 안된다. 그러므로 이걸 이용해서
                // 업데이트를 하자.
                console.log(str);
                ip.push(str);
            }
        }
    }

    return ip;
}



/*

Example

function ExampleSocketUrl()
{
    return GetSocketUrl(location.host, "WsA");
}

*/


