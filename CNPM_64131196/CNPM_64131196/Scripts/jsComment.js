$(document).ready(function () {
    $('body').on('click', '.btnComment', function (e) {
        e.preventDefault();
        var rating = $('#ratingPT').val();
        var txtComment = $('#txtComment').val();
        var idPT = $('#txtIDPersonalTrainer').val();

        if (txtComment === "") {
            bootbox.alert("Bạn chưa nhập bình luận");
            return;
        }       

        $.ajax({
            url: '/comment/add',
            type: 'POST',
            data: {
                idPt: idPT,
                rating: rating,
                comment: txtComment
            },
            success: function (res) {
                if (res.Success) {
                    $('#txtComment').val("");
                    LoadComment();
                }
                
            }
        });
    });

    $('body').on('click', '.btnDeleteComment', function (e) {
        e.preventDefault();

        var idComment = $(this).data('id');
        $('#id_comment').val(idComment);                
        $('#confirmDeleteComment').modal('show');
    });

    $('body').on('click', '.btnXacNhanXoaCmt', function (e) {
        e.preventDefault();
        $('#confirmDeleteComment').modal('hide');
        var id_comment = $('#id_comment').val();      

        $.ajax({
            url: '/comment/delete',
            type: 'POST',
            data: {
                id: id_comment
            },
            success: function (res) {
                if (res.Success) {                    
                    LoadComment();
                }
            }
        });
    });

    $('body').on('click', '.btnEditComment', function (e) {
        e.preventDefault();
        var id = $(this).data('id');

        $('#comment-text-' + id).addClass('d-none');

        $('#edit-comment-' + id).removeClass('d-none');
        $('#edit-comment-' + id).focus();
        $(".btnSaveEdit[data-id='" + id + "']").removeClass("d-none");
    });   

    $('body').on('click', '.btnSaveEdit', function (e) {
        e.preventDefault();
        var id = $(this).data('id');

        var newComment = $('#edit-comment-' + id).val();
        if (newComment === "") {
            bootbox.alert("Nội dung trống");

            return;
        } 

        $.ajax({
            url: '/comment/update',
            type: 'POST',
            data: {
                id: id,
                newComment: newComment
            },

            success: function (res) {
                if (res.Success) {
                    LoadComment();
                }
            }
        });
    });   

    function LoadComment() {
        var idPT = $('#txtIDPersonalTrainer').val();

        $.ajax({
            url: '/comment/partial_comments',
            type: 'GET',
            data: {
                id: idPT,               
            },
            success: function (res) {
                $('#load_comments').html(res);
            }
        });
    }    
});