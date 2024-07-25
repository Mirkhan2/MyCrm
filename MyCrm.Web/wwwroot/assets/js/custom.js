function fillPageId(id) {
    console.log(id);
    $('#pageId').val(id);
    $('#filter-search').submit();
}

function ShowMessage(title, text, them) {
    window.createNotficatrion({
        closedOnClick: true,
        displayCloseButton: false,
        positionClass: 'nfc-botton-right',
        showDurations: 5000,
        them: them !== '' ? them : 'success',

    })({
        title: title !== '' ? title : 'Elan', 
        message :text
    })
}

$("[ImageInput]").change(function () {
    var x = $(this).Attr("ImageInput");
    if (this.files && this.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("[ImageFile=" + x + "]").Attr('src', e.target.result);
        };
        reader.readAsDataURL(this.files[0]);

    }
})