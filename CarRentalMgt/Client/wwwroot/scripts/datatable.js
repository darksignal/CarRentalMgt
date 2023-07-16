//DRG Script to be used in the Index.HTML file to add or dispose the DataTable
//    and will be used in the Index.razor from the different pages Bookings, etc...
function AddDataTable(table) {
    $(document).ready(function () {
        $(table).DataTable();
    })
}

function DisposeDataTable(table) {
    $(document).ready(function () {
        $(table).DataTable().destroy();
        var element = document.querySelector(table + '_wrapper');
        element.parentNode.removeChild(element);
    })
}