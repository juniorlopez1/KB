
function ValidarNumeros(event) {
    //solo numeros
    event = event || window.event;

    var charCode = event.keyCode || event.which;

    var first = (charCode <= 57 && charCode >= 49);

    return first;
}

function lettersOnly() {
    //solo letras
    var charCode = event.keyCode;

    if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8)

        return true;
    else
        return false;
}