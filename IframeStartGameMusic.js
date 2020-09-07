var presentpageLocation = iframe.get(0).contentWindow.location.pathname;
var previousPage;

function SetMusic() {

    var iframe = $('#iframeMain');
    var href = iframe.get(0).contentWindow.location.pathname;
    var audio = document.getElementById('StartMusic');

    // Only for testing purposes.
     console.log(href);
    // console.log(iframe.get(0).contentWindow.location);
     console.log(previousPage);
    // console.log(iframe.document.referrer);

    if (previousPage != "/StartStoryOfTheFighter" && previousPage != "/BackPack" && previousPage != "/LuckWiev") {

        if (href == "/StartStoryOfTheFighter") {
            audio.src = "Music/In_The_Clouds_David_Fesliyan.mp3";
        }
    }

    if (href == "/RestPage") {
        audio.src = "";
    }

    if (href == "/BattleWithAjax") {
        audio.src = "";
    }

    if (previousPage != "/LevelUpp") {
        if (href == "/LevelUpp") {
            audio.src = "Music/LevelUpp.mp3";
        }
    }
    previousPage = iframe.get(0).contentWindow.location.pathname;
}