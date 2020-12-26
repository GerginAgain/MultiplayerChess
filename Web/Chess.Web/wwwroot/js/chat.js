$(document).ready(function () {
    connection.on("ReceiveNewMessage", function (userName, message) {
        var chatInfo = `<div class="text-danger">${userName}: ${escapeHtml(message)}</div>`;
        $("#messagesList").append(chatInfo);

        var messageList = document.getElementById("messagesList");
        messageList.scrollTop = messageList.scrollHeight;
    });

    $("#sendButton").click(function () {
        var message = $("#messageInput").val();
        var chatInfo = `<div class="text-primary">Me: ${escapeHtml(message)}</div>`;
        $("#messagesList").append(chatInfo);
        $("#messageInput").val("");
        connection.invoke("SendNewMessage", message, gameId);

        var messageList = document.getElementById("messagesList");
        messageList.scrollTop = messageList.scrollHeight;
    });

    $("#messageInput").keyup(function (event) {
        if (event.keyCode === 13 && ($("#messageInput").val() !== "")) {
            event.preventDefault();
            $("#sendButton").click();
        }
    });

    function escapeHtml(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");
    }
});