
//Validación Fecha
var dateToday = new Date();
$(function () {
    $("#datepicker").datepicker({
        //beforeShowDay: $.datepicker.noWeekends,
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
        dateFormat: 'DD, d MM, yy',
        showButtonPanel: true,
        minDate: 1
    });
});

//PopUp Modal
$(document).ready(function () {
    $("#myBtn").click(function () {
        $("#exampleModalLong").modal({
            backdrop: 'static',
            keyboard: false
        });
    });
});





function openModal() {
    $('#exampleModalLong').modal({
        backdrop: 'static',
        keyboard: false
    });
}



//Fecha
$(function () {
    $("#datepicker").datepicker();
});

//Hora

$('#datetimepicker5').datetimepicker({
    datepicker : false,
    ampm: true,
    format: 'G:i A',
    format: 'G:i A',
    allowTimes: ['8:00', '9:00 ', '10:00', '11:00', '12:00', '01:00', '02:00 PM', '03:00', '04:00', '05:00'],

});


//Validate Empty inputs
var btnEnviar = document.getElementById("btnEnviarPedido");
btnEnviar.disabled = true

function validar() {

    var fecha = document.getElementById("datepicker");
    var hora = document.getElementById("datetimepicker5");

    if (fecha.value.length !=0 && hora.value.length != 0) {
        btnEnviar.disabled = false;
    }
}


$('#checkBoxAluminio').click(function () {

    if ($(this).is(':checked')) {

        $('#listaCantidadAluminio').removeAttr('disabled');
        document.getElementById("listaCantidadAluminio").style.color = "black";
        document.getElementById("inputTotalAluminio").style.color = "black";
        document.getElementById("inputTotalAluminio").textContent = '50';

    } else {

        $('#listaCantidadAluminio').attr('disabled', true);
        document.getElementById("listaCantidadAluminio").style.color = "#ddd";
        document.getElementById("listaCantidadAluminio").value = '1';
        document.getElementById("inputTotalAluminio").style.color = "#ddd";
        document.getElementById("inputTotalAluminio").textContent = '0';


    }
});

$('#checkBoxPlastico').click(function () {

    if ($(this).is(':checked')) {

        $('#listaCantidadPlastico').removeAttr('disabled');
        document.getElementById("listaCantidadPlastico").style.color = "black";
        document.getElementById("listaCantidadPlastico").value = '1';
        document.getElementById("inputTotalPlastico").style.color = "Black";
        document.getElementById("inputTotalPlastico").textContent = '20';

    } else {

        $('#listaCantidadPlastico').attr('disabled', true);
        document.getElementById("listaCantidadPlastico").style.color = "#ddd";
        document.getElementById("inputTotalPlastico").style.color = "#ddd";
        document.getElementById("listaCantidadPlastico").value = '1';
        document.getElementById("inputTotalPlastico").textContent = '0';


    }
});

$('#checkBoxPolietileno').click(function () {

    if ($(this).is(':checked')) {

        $('#listaCantidadPolietileno').removeAttr('disabled');
        document.getElementById("listaCantidadPolietileno").style.color = "black";
        document.getElementById("inputTotalPolietileno").style.color = "Black";
        document.getElementById("inputTotalPolietileno").textContent = '50';

    } else {

        $('#listaCantidadPolietileno').attr('disabled', true);
        document.getElementById("listaCantidadPolietileno").style.color = "#ddd";
        document.getElementById("listaCantidadPolietileno").value = '1';
        document.getElementById("inputTotalPolietileno").style.color = "#ddd";
        document.getElementById("inputTotalPolietileno").textContent = '0';



    }
});

$('#checkBoxVidrio').click(function () {

    if ($(this).is(':checked')) {

        $('#listaCantidadVidrio').removeAttr('disabled');
        document.getElementById("listaCantidadVidrio").style.color = "black";
        document.getElementById("inputTotalVidrio").style.color = "Black";
        document.getElementById("inputTotalVidrio").textContent = '25';

    } else {

        $('#listaCantidadVidrio').attr('disabled', true);
        document.getElementById("listaCantidadVidrio").style.color = "#ddd";
        document.getElementById("inputTotalVidrio").style.color = "#ddd";
        document.getElementById("listaCantidadVidrio").value = '1';
        document.getElementById("inputTotalVidrio").textContent = '0';


    }
});


//carton
$('#checkBoxCarton').click(function () {

    if ($(this).is(':checked')) {

        $('#listaCantidadCarton').removeAttr('disabled');
        document.getElementById("listaCantidadCarton").style.color = "black";
        document.getElementById("inputTotalCarton").style.color = "Black";
        document.getElementById("inputTotalCarton").textContent = '20';

    } else {

        $('#listaCantidadCarton').attr('disabled', true);
        document.getElementById("listaCantidadCarton").style.color = "#ddd";
        document.getElementById("listaCantidadCarton").value = '1';
        document.getElementById("inputTotalCarton").style.color = "#ddd";
        document.getElementById("inputTotalCarton").textContent = '0';

    }
});


$('#checkBoxPapel').click(function () {

    if ($(this).is(':checked')) {

        $('#listaCantidadPapel').removeAttr('disabled');
        document.getElementById("listaCantidadPapel").style.color = "black";
        document.getElementById("inputTotalPapel").style.color = "Black";
        document.getElementById("inputTotalPapel").textContent = '20';

    } else {

        $('#listaCantidadPapel').attr('disabled', true);
        document.getElementById("listaCantidadPapel").style.color = "#ddd";
        document.getElementById("listaCantidadPapel").value = '1';
        document.getElementById("inputTotalPapel").style.color = "#ddd";
        document.getElementById("inputTotalPapel").textContent = '0';


    }
});

$('#checkBoxTetrabrik').click(function () {

    if ($(this).is(':checked')) {

        $('#listaCantidadTetrabrik').removeAttr('disabled');
        document.getElementById("listaCantidadTetrabrik").style.color = "black";
        document.getElementById("inputTotalTetrabrik").style.color = "Black";
        document.getElementById("inputTotalTetrabrik").textContent = '25';

    } else {

        $('#listaCantidadTetrabrick').attr('disabled', true);
        document.getElementById("listaCantidadTetrabrik").style.color = "#ddd";
        document.getElementById("listaCantidadTetrabrik").value = '1';
        document.getElementById("inputTotalTetrabrik").style.color = "#ddd";
        document.getElementById("inputTotalTetrabrik").textContent = '0';


    }
});


//funcion calculo de hojas ~ cliente
var calcCliente = document.getElementById("btnCalcularCliente");
if (calcCliente) {
    calcCliente.addEventListener("click", calcularCliente);
}
function calcularCliente() {

    var total = 0;

    //Calculo Aluminio
    var totalAluminio = 0;
    var iTotalAluminio = document.getElementById("inputTotalAluminio");
    var dCantidadAluminio = document.getElementById("listaCantidadAluminio");
    var valorCantidadAluminio = dCantidadAluminio.options[dCantidadAluminio.selectedIndex].value;

    if (document.getElementById('checkBoxAluminio').checked) {

        totalAluminio = valorCantidadAluminio * 50;
        iTotalAluminio.innerHTML = totalAluminio;
    }

    //Calculo Plastico
    var totalPlastico = 0;
    var iTotalPlastico = document.getElementById("inputTotalPlastico");
    var dCantidadPlastico = document.getElementById("listaCantidadPlastico");
    var valorCantidadPlastico = dCantidadPlastico.options[dCantidadPlastico.selectedIndex].value;

    if (document.getElementById('checkBoxPlastico').checked) {

        totalPlastico = valorCantidadPlastico * 20;
        iTotalPlastico.innerHTML = totalPlastico;

    }
    //Calculo Polietileno
    var totalPolietileno = 0;
    var iTotalPolietileno = document.getElementById("inputTotalPolietileno");
    var dCantidadPolietileno = document.getElementById("listaCantidadPolietileno");
    var valorCantidadPolietileno = dCantidadPolietileno.options[dCantidadPolietileno.selectedIndex].value;

    if (document.getElementById('checkBoxPolietileno').checked) {

        totalPolietileno = valorCantidadPolietileno * 50;
        iTotalPolietileno.innerHTML = totalPolietileno;

    }
    //Calculo Vidrio
    var totalVidrio = 0;
    var iTotalVidrio = document.getElementById("inputTotalVidrio");
    var dCantidadVidrio = document.getElementById("listaCantidadVidrio");
    var valorCantidadVidrio = dCantidadVidrio.options[dCantidadVidrio.selectedIndex].value;

    if (document.getElementById('checkBoxVidrio').checked) {

        totalVidrio = valorCantidadVidrio * 25;
        iTotalVidrio.innerHTML = totalVidrio;
    }

    //Calculo carton
    var totalCarton = 0;
    var iTotalCarton = document.getElementById("inputTotalCarton");
    var dCantidadCarton = document.getElementById("listaCantidadCarton");
    var valorCantidadCarton = dCantidadCarton.options[dCantidadCarton.selectedIndex].value;

    if (document.getElementById('checkBoxCarton').checked) {
        totalCarton = valorCantidadCarton * 20;
        iTotalCarton.innerHTML = totalCarton;
    }
    //Papel
    var totalPapel = 0;
    var iTotalPapel = document.getElementById("inputTotalPapel");
    var dCantidadPapel = document.getElementById("listaCantidadPapel");
    var valorCantidadPapel = dCantidadPapel.options[dCantidadPapel.selectedIndex].value;

    if (document.getElementById('checkBoxPapel').checked) {
        totalPapel = valorCantidadPapel * 20;
        iTotalPapel.innerHTML = totalPapel;
    }
    //Papel
    var totalTetrabrik = 0;
    var iTotalTetrabrik = document.getElementById("inputTotalTetrabrik");
    var dCantidadTetrabrik = document.getElementById("listaCantidadTetrabrik");
    var valorCantidadTetrabrik = dCantidadTetrabrik.options[dCantidadTetrabrik.selectedIndex].value;

    if (document.getElementById('checkBoxTetrabrik').checked) {
        totalTetrabrik = valorCantidadTetrabrik * 25;
        iTotalTetrabrik.innerHTML = totalTetrabrik;
    }

    //Calculo Total
    total = totalAluminio + totalPlastico + totalPolietileno + totalVidrio + totalCarton + totalPapel + totalTetrabrik;

    var filas = document.querySelectorAll("#tableHojas tfoot tr td");
    filas[3].textContent = total;


}

//funcion calculo de hojas ~ Recolector
var calcRecolector = document.getElementById("btnCalcular");

if (calcRecolector) {
    calcRecolector.addEventListener("click", calcular);
}

function calcular() {

    var filas = document.querySelectorAll("#tableHojas tbody tr");

    var total = 0;

    // recorremos cada una de las filas
    filas.forEach(function (e) {

        // obtenemos las columnas de cada fila
        var columnas = e.querySelectorAll("td");

        // obtenemos los valores 
        var cantidad = parseFloat(columnas[1].textContent);
        var valorTetrabrick = 20;


        // mostramos el total por fila
        columnas[2].textContent = (cantidad * 20);

        total += cantidad * 20;

        // mostramos la suma total
        var filas = document.querySelectorAll("#tableHojas tfoot tr td");
        filas[2].textContent = total;
    });


}


//Checkboxs

//btn var
document.getElementById("listaCantidadAluminio").style.color = "#ddd";
document.getElementById("listaCantidadAluminio").disabled = true;
document.getElementById("inputTotalAluminio").style.color = "#ddd";

document.getElementById("listaCantidadPlastico").style.color = "#ddd";
document.getElementById("listaCantidadPlastico").disabled = true;
document.getElementById("inputTotalPlastico").style.color = "#ddd";

document.getElementById("listaCantidadPolietileno").style.color = "#ddd";
document.getElementById("listaCantidadPolietileno").disabled = true;
document.getElementById("inputTotalPolietileno").style.color = "#ddd";

document.getElementById("listaCantidadVidrio").style.color = "#ddd";
document.getElementById("listaCantidadVidrio").disabled = true;
document.getElementById("inputTotalVidrio").style.color = "#ddd";

document.getElementById("listaCantidadCarton").style.color = "#ddd";
document.getElementById("listaCantidadCarton").disabled = true;
document.getElementById("inputTotalCarton").style.color = "#ddd";

document.getElementById("listaCantidadPapel").style.color = "#ddd";
document.getElementById("listaCantidadPapel").disabled = true;
document.getElementById("inputTotalPapel").style.color = "#ddd";

document.getElementById("listaCantidadTetrabrik").style.color = "#ddd";
document.getElementById("listaCantidadTetrabrik").disabled = true;
document.getElementById("inputTotalTetrabrik").style.color = "#ddd";






