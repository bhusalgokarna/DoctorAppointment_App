$(document).ready(function () {     
    GetDoctor();
    $('#Doctor').change(function () {
        var id = $(this).val();
        $('#DateSlot').empty();
        $('#DateSlot').append('<Option>--Available Dates are--</Option>');
        $.ajax({
            url: '/Appointment/DateSlot?id=' +id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#DateSlot').append("<Option value=" + data.id + '>' + data.availableDay + "</Option>");
                });
                $('#DateSlot').change(function () {
                    GetTimeSlot();
                });
            }
        });
    });
    $('#Doctor').change(function () {
        GetTimeSlot();
    });
    $('#DateSlote').change(function () {
        GetTimeSlot();
    });
    $('#Doctor').change(function () {
        var id = $(this).val();
        $('#Patient').empty();
        $('#Patient').append('<Option>--Select Patient--</Option>');
        $.ajax({
            url: '/Appointment/Patient?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Patient').append('<Option value=' + data.id + '>' + data.name + '</Option>');
                });
            }
        });
    });
});

function GetDoctor() {
    $.ajax({
        url: '/Appointment/Doctor',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Doctor').append('<Option value=' + data.id +'>' + data.name + '</Option>');
            });
        }
    });
}
function GetTimeSlot() {
    var id = $('#Doctor').val();
    var dateId = $("#DateSlot").val();
    $('#TimeSlot').empty();
    $('#TimeSlot').append('<Option>--Select Time From Available TimeSlot--</Option>');
    $.ajax({
        url: '/Appointment/TimeSlot?id=' + id + '&dateId=' + dateId,
        success: function (result) {
            $.each(result, function (i, data) {
                $('#TimeSlot').append('<Option value=' + data.id + '>' + data.availAbleTime + '</Option>');
            });
        }
    });
}
