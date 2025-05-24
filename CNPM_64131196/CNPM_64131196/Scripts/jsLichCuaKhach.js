$(document).ready(function () {
    $('body').on('click', '.btnXoaLich', function (e) {
        e.preventDefault();
        var idLichCuaKhach = $(this).data('id');

        $('#LichCuaKhach').val(idLichCuaKhach);
        $('#confirmModalXoaLich').modal('show');       
    });

    $('body').on('click', '.btnXacNhanXoaLich', function (e) {
        e.preventDefault();
        var idLich = $('#LichCuaKhach').val();

        $('#confirmModalXoaLich').modal('hide');


        $.ajax({
            url: '/lichtap/xoalich',
            type: 'POST',
            data: { id: idLich },
            success: function (res) {
                if (res.Success) {
                    $('#txtSuccess').text(res.msg);
                    $('#statusSuccessModal').modal('show');
                    LoadCalendar();
                }
                else {
                    $('#txtError').text(res.msg);
                    $('#statusErrorsModal').modal('show');
                }
            }
        });
    });

    function LoadCalendar() {
        var idUser = $('#id_user').val();

        $.ajax({
            url: '/lichtap/parttial_lichcuakhach',
            type: 'GET',
            data: { idKH: idUser },
            success: function (res) {
                $('#load_lichkhach').html(res);
            }
        });
    }
});