$(document).ready(function () {
    var elementForRemoveId;

    $('.DeleteButton').on('click',
        function () {
            elementForRemoveId = $(this).val();
            let gameId = elementForRemoveId;
            var token = $("[name='__RequestVerificationToken']").val();
            $.ajax({
                method: "POST",
                url: "/Administration/Games/Delete",
                data: {
                    __RequestVerificationToken: token,
                    gameId: gameId,
                },
                dataType: "json",
                success: function () {
                    $(`#${elementForRemoveId}`).remove();
                }
            });
        });
});
