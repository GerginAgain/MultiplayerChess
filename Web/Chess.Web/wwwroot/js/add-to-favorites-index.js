$(document).ready(function () {    
    function AddEventToEmptyFavouriteIcon(){
        $("i.far").on('click', function (event) {
            event.stopImmediatePropagation();
            var videoId = $(this).attr('id');
            var token = $("[name='__RequestVerificationToken']").val();
            console.log(videoId);

            $.ajax({
                url: "/Favourites/Add",
                type: "POST",
                data: {
                    __RequestVerificationToken: token,
                    videoId: videoId,
                },
                dataType: 'json',
                success: function () {
                    $(function () {
                        $('#add-favorites-modal').modal('show');
                        $(function () {
                            var myModal = $('#add-favorites-modal');
                            clearTimeout(myModal.data('hideInterval'));
                            myModal.data('hideInterval', setTimeout(function () {
                                myModal.modal('hide');
                            }, 2500));
                        });
                    });
                    $("#" + videoId).replaceWith('<i id="' + videoId + '"' + 'class="fas fa-star fa-3x text-warning"></i>');
                    AddEventToFullFavouriteIcon();
                }
            });
        });
    } 

    function AddEventToFullFavouriteIcon() {
        $("i.fas").on('click', function (event) {
            event.stopImmediatePropagation();
            var videoId = $(this).attr('id');
            var token = $("[name='__RequestVerificationToken']").val();
            console.log(videoId);
            $.ajax({
                url: "/Favourites/Remove",
                type: "POST",
                data: {
                    __RequestVerificationToken: token,
                    videoId: videoId,
                },
                dataType: 'json',
                success: function (response) {
                    $(function () {
                        $('#remove-favorites-modal').modal('show');
                        $(function () {
                            var myModal = $('#remove-favorites-modal');
                            clearTimeout(myModal.data('hideInterval'));
                            myModal.data('hideInterval', setTimeout(function () {
                                myModal.modal('hide');
                            }, 2500));
                        });
                    });
                    $("#" + videoId).replaceWith('<i id="' + videoId + '"' + 'class="far fa-star fa-3x text-warning"></i>');
                    AddEventToEmptyFavouriteIcon();
                }
            });
        });
    }

    AddEventToEmptyFavouriteIcon();
    AddEventToFullFavouriteIcon();
});
