function previewImage(event, querySelector) {

    //Recuperamos el input que desencadeno la acción
    const input = event.target;

    $imgPreview = document.querySelector(querySelector);

    if (!input.files.length) return

    file = input.files[0];

    objectURL = URL.createObjectURL(file);

    $imgPreview.src = objectURL;

}

//$(document).ready(function () {
//    $('.open-modal').on('click', function () {
//        var animalId = $(this).data('id');
//        var targetModal = $(this).data('bs-target');

//        if (targetModal === '#clinicalHistoryModal') {
//            $.ajax({
//                url: 'GetClinicalHistory.aspx',  // La página o el controlador que devuelve el historial clínico
//                type: 'GET',
//                data: { id: animalId },
//                success: function (data) {
//                    $('#clinicalHistoryModal #modalBodyContent').html(data);
//                },
//                error: function () {
//                    $('#clinicalHistoryModal #modalBodyContent').html('<p>Ocurrió un error al cargar el historial clínico.</p>');
//                }
//            });
//        } else if (targetModal === '#agendaCitaModal') {
//            $.ajax({
//                url: 'GetAppointmentForm.aspx',  // La página o el controlador que devuelve el formulario de agendar cita
//                type: 'GET',
//                data: { id: animalId },
//                success: function (data) {
//                    $('#agendaCitaModal #modalBodyContent').html(data);
//                },
//                error: function () {
//                    $('#agendaCitaModal #modalBodyContent').html('<p>Ocurrió un error al cargar el formulario de agendar cita.</p>');
//                }
//            });
//        }
//    });
//});
