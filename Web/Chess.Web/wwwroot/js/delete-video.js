$(document).ready(function () {
    var elementForRemove;
    $(".elm").click(function () {
        elementForRemove = $(this);
    });

    $('.delete-video').on('click',
        function () {
            let videoId = $(this).val();
            var token = $("[name='__RequestVerificationToken']").val();
            $.ajax({
                method: "POST",
                url: "/Administration/Videos/Delete",
                data: {
                    __RequestVerificationToken: token,
                    videoId: videoId,
                },
                dataType: "json",
                success: function () {
                    elementForRemove.hide('slow', function () { elementForRemove.remove(); });
                    $(function () {
                        $('#modal').modal('show');
                        $('.modal-message').html('You have successfully deleted this video!');
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