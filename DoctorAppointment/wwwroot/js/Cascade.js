$(document).ready(function () {
    GetDoctor();

    $('#Doctor').change(function () {
        var id = $(this).val();
        $('#DateSlot').empty();

        $.ajax({
            url: '/Appointment/DateSlot?id=' + id,
            success: function (result) {
                $('#DateSlot').empty(); // Leeg het DateSlot-element

                $.each(result, function (i, data) {
                    $('#DateSlot').append("<Option value=" + data.id + '>' + data.availableDay + "</Option>");
                });

                // Roep GetTimeSlot() aan na het succesvol voltooien van het AJAX-verzoek
                GetTimeSlot();
            }
        });

        // Voeg hier eventuele andere code toe
    });

    // Hier kun je andere event handlers toevoegen of eventuele andere initialisatie uitvoeren
});

function GetDoctor() {
    $.ajax({
        url: '/Appointment/Doctor',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Doctor').append('<Option value=' + data.id + '>' + data.name + '</Option>');
            });
        }
    });
}

function GetTimeSlot() {
    var id = $('#Doctor').val();
    var dateId = $("#DateSlot").val();
    $('#TimeSlot').empty();

    $.ajax({
        url: '/Appointment/TimeSlot?id=' + id + '&dateId=' + dateId,
        success: function (result) {
            $.each(result, function (i, data) {
                $('#TimeSlot').append('<Option value=' + data.id + '>' + data.availAbleTime + '</Option>');
            });
        }
    });
}

function test() {
    alert("changed called");
}
