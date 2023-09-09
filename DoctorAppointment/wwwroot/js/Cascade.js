
$(document).ready(function () {
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
                /* GetTimeSlot(); */
            }
        });
       
        $('#Patient').empty();

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


