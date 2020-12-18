$(document).ready(function () {
    var elementForRemove;
    $(".elm").click(function () {
        elementForRemove = $(this);
    });

    $('.restore-video').on('click',
        function () {
            let videoId = $(this).val();
            var token = $("[name='__RequestVerificationToken']").val();
            $.ajax({
                method: "POST",
                url: "/Administration/Videos/Restore",
                //data: "userId=" + userId,
                data: {
                    __RequestVerificationToken: token,
                    videoId: videoId,
                },
                dataType: "json",
                success: function () {
                    elementForRemove.hide('slow', function () { elementForRemove.remove(); });
                    $(function () {
                        $('#modal').modal('show');
                        $('.modal-message').html('You have successfully restored this video!');
                        $(function () {
                            var myModal = $('#modal');
                            clearTimeout(myModal.data('hideInterval'));
                            myModal.data('hideInterval', setTimeout(function () {
                                myModal.modal('hide');
                            }, 3000));
                        });
                    });
                }
            });
        });
});