
$(document).ready(function (){

    document.getElementById('ButtonContinue').style.display = "none"
    // $('#ButtonRest').click(Rest());
});

function Rest() {
    $('#ButtonRest').hide();
    document.getElementById('ButtonContinue').style.display = "initial"
    $('#LabelRest').show();
    $('#LabelRest').html("<h1>You could rest well, and you woke up refreshed and healed. Let's continue your journey.</h1>");
}