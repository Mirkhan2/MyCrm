
function fillPageId(id) {
    console.log(id);
    $('#pageId').val(id);
    $('#filter-search').submit();
}

function ShowMessage(title, text, theme) {
    window.createNotification({
        closeOnClick: true,
        displayCloseButton: false,
        positionClass: 'nfc-bottom-right',
        showDuration: 5000,
        theme: theme !== '' ? theme : 'success',
    })({
        title: title !== '' ? title : 'اعلان',
        message: text
    });
}

$("[ImageInput]").change(function () {
    var x = $(this).attr("ImageInput");
    if (this.files && this.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("[ImageFile=" + x + "]").attr('src', e.target.result);
        };
        reader.readAsDataURL(this.files[0]);
    }
});


var datePickers = $('.datePicker-custom');

if (datePickers.length) {

    datePickers.each(function (index, value) {
        var pickerId = $(value).attr("id");
        kamaDatepicker(pickerId,
            {
                forceFarsiDigits: true,
                markToday: true,
                markHolidays: true,
                highlightSelectedDay: true,
                sync: true,
                gotoToday: true,
            });
    });
}

function ConfirmBtn(ev) {
    ev.preventDefault();
    var urlRedirect = ev.currentTarget.getAttribute('href');
    Swal.fire({
        title: 'اعلان',
        text: "آیا از انجام این عملیات اطمینان دارید؟",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = urlRedirect;
        }
    });
}


