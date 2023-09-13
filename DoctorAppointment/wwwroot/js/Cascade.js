
$(document).ready(function () {
    GetDoctors();

    // Handle Doctor dropdown change
    $('#Doctor').change(function () {
        var id = $(this).val();

        $('#DateSlot').empty();
        $('#TimeSlot').empty(); // Clear TimeSlot dropdown when Doctor changes
        $('#Patient').empty();

        $.ajax({
            url: '/Appointment/DateSlot?id=' + id,
            success: function (result) {
              //  $('#DateSlot').empty();
                $.each(result, function (i, data) {
                    $('#DateSlot').append("<option value=" + data.id + '>' + data.availableDay + "</option>");
                });

                // Now, you can make the TimeSlot AJAX request here
                var dateId = $("#DateSlot").val();
              //  $('#TimeSlot').empty();
                $.ajax({
                    url: '/Appointment/TimeSlot?id=' + id + '&dateId=' + dateId,
                    success: function (result) {
                        $.each(result, function (i, data) {
                            $('#TimeSlot').append('<option value=' + data.id + '>' + data.availAbleTime + '</option>');
                        });
                    }
                });
                $.ajax({
                    url: '/Appointment/Patient?id=' + id,
                    success: function (result) {
                        $.each(result, function (i, data) {
                            $('#Patient').append('<option value=' + data.id + '>' + data.name + '</option>');
                        });
                    }
                });
                // Rest of your code...
            }
        });
    })
})

function GetDoctors() {
    $.ajax({
        url: '/Appointment/Doctor',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Doctor').append('<option value=' + data.id + '>' + data.name + '</option>');
            });
        }
    });
}


