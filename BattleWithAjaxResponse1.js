//Global variables.
var DisplayLine = 0;
var IncriseMillisecoundsToWait = 1000;
var ResposeLines = [];
var Characters = {};
var IDDisplayFight;
var Paused = false;
var RoundNumber = 1;
var ResponseObj;

$(document).ready(function () {
    //Disabled buttons are faded out to 0.3. 
    $("#btnStopFight").fadeTo(0, 0.3);
    $("#btnSpeedUp").fadeTo(0, 0.3);
    $("#btnSlowDown").fadeTo(0, 0.3);
    
    let enemypictureWidth = document.getElementById("ImageEnemy1").offsetWidth;
    $("#tblEnemey").css({ 'right': enemypictureWidth + 'px' });
})

function StartFight() {
    //Enable and fadeTo 1 control buttons.
    $("#btnStartFight").hide();
    $("#btnStopFight").prop('disabled', false);
    $("#btnSpeedUp").prop('disabled', false);
    $("#btnSlowDown").prop('disabled', false);
    $("#btnStopFight").fadeTo(0, 1);
    $("#btnSpeedUp").fadeTo(0, 1);
    $("#btnSlowDown").fadeTo(0, 1);

    //Start the fight.
    NextRound();
}

function NextRound() {

    //Check if not paused or one of the characters are dead.
    if (!Paused) {
        //Do the ajax call for next round.
        $.ajax({
            url: 'ResponseBattleWithAjax.aspx',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            async: false
        })
            .then(function (responseObj) {
                //Put responseObj in a global variable.
                ResponseObj = responseObj;

                if (!responseObj.Player.Alive || !responseObj.Enemy.Alive) {
                    // Display last round and stop running.
                    CreateFightDescription(responseObj);
                    DisplayLine = 0;
                    IDDisplayFight = DisplayFightLastRoundWithEndAnimations();
                    PlayFightAnimations(responseObj);
                    if (!responseObj.Player.Alive) {
                        setTimeout(function () { AnimationEnemyWins(); }, IncriseMillisecoundsToWait * 10);
                    }
                    else {
                        setTimeout(function () { AnimationPlayerWins(); }, IncriseMillisecoundsToWait * 10);
                    }
                }
                else {
                    CreateFightDescription(responseObj);
                    DisplayLine = 0;
                    IDDisplayFight = setInterval(function () { DisplayFight(); }, IncriseMillisecoundsToWait);
                    PlayFightAnimations(responseObj);
                }
            })
    }
};


//Displayes the current fight round by continously summoning the DisplayFight() function
//and attaches and displayes the last line of the battle to the very end of description.
function DisplayFightLastRoundWithEndAnimations() {
    IDDisplayFight = setInterval(function () { DisplayLastRound(); }, IncriseMillisecoundsToWait);
    setTimeout(function () { FadeOutAudio(); }, IncriseMillisecoundsToWait * 10);
    setTimeout(function () { FadeOutControlPanel(); }, IncriseMillisecoundsToWait * 8);
    setTimeout(function () { CreateAndDisplayBtnContinueGame(); }, IncriseMillisecoundsToWait * 10);

}

//Fulfill the ResposeLines array of fight description based on server response object.
function CreateFightDescription(ojbJSON) {
    ResposeLines = [];
    var index = 0;
    ResposeLines[index] = "Round " + ojbJSON.RoundNumber;
    index++;
    ResposeLines[index] = ojbJSON.Player.Name + "'s initiation: " + ojbJSON.Player.Initiation;
    index++;
    ResposeLines[index] = ojbJSON.Enemy.Name + "'s initiation: " + ojbJSON.Enemy.Initiation;
    index++;
    if (ojbJSON.Player.Initiation >= ojbJSON.Enemy.Initiation) {
        index = DisplayPlayerAttackFirst(ojbJSON, index);
    }
    else {
        index = DisplayEnemyAttackFirst(ojbJSON, index);
    }
    index = DisplayIfCharacterPoisoned(ojbJSON.Player, index);
    index = DisplayIfCharacterPoisoned(ojbJSON.Enemy, index);
    ResposeLines[index] = "ROUND HAS FINISHED";
    index++;
    //Check if one of the characters is dead and add last line to ResposeLines[] array.
    if (ojbJSON.Player.Alive == false) {
        ResposeLines[ResposeLines.length] = "You have died! Enemy won the battle!";
        index++;
    }
    else if (ojbJSON.Enemy.Alive == false) {
        ResposeLines[ResposeLines.length] = "The enemy died! You won the battle!";
        index++;
    }
    else {
    }
}

//Creates the fight description into Responselines[] if the player hits first, and returns the ResposeLines array's index.
function DisplayPlayerAttackFirst(ojbJSON, index) {
    ResposeLines[index] = ojbJSON.Player.Name + " hit's " + ojbJSON.Enemy.Name;
    index++;
    if (ojbJSON.PlayerHitEnemy) {
        ResposeLines[index] = "Succesfull hit!";
        index++;
        ResposeLines[index] = "Damage on " + ojbJSON.Enemy.Name + ": " + (ojbJSON.Player.MyWeapon.WeaponDamage);
        index++;
        //Fight back.
        ResposeLines[index] = ojbJSON.Enemy.Name + " hit's " + ojbJSON.Player.Name;
        index++;
        if (ojbJSON.EnemyHitPlayer) {
            ResposeLines[index] = "Succesfull hit!";
            index++;
            if (ojbJSON.Enemy.MyWeapon.WeaponDamage > ojbJSON.Player.MyArmour.DamageReduction) {
                ResposeLines[index] = "Damage on " + ojbJSON.Player.Name + ": " + (ojbJSON.Enemy.MyWeapon.WeaponDamage - ojbJSON.Player.MyArmour.DamageReduction);
                index++;
            } else {
                ResposeLines[index] = "Damage on " + ojbJSON.Player.Name + ": 0";
                index++;
            }
        }
        else {
            ResposeLines[index] = "MISS!!!";
            index++;
        }
    }
    else {
        ResposeLines[index] = "MISS!!!";
        index++;
        //Fight back.
        ResposeLines[index] = ojbJSON.Enemy.Name + " hit's " + ojbJSON.Player.Name;
        index++;
        if (ojbJSON.EnemyHitPlayer) {
            ResposeLines[index] = "Succesfull hit!";
            index++;
            ResposeLines[index] = "Damage on " + ojbJSON.Player.Name + ": " + (ojbJSON.Enemy.MyWeapon.WeaponDamage - ojbJSON.Player.MyArmour.DamageReduction);
            index++;
        }
        else {
            ResposeLines[index] = "MISS!!!";
            index++;
        }
    }
    return index;
}

//Creates the fight description into ResponseLines[] if the Enemy hits first, and returns the ResposeLines array's index.
function DisplayEnemyAttackFirst(ojbJSON, index) {
    ResposeLines[index] = ojbJSON.Enemy.Name + " hit's " + ojbJSON.Player.Name;
    index++;
    if (ojbJSON.EnemyHitPlayer) {
        ResposeLines[index] = "Succesfull hit!";
        index++;
        if (ojbJSON.Enemy.MyWeapon.WeaponDamage > ojbJSON.Player.MyArmour.DamageReduction) {
            ResposeLines[index] = "Damage on " + ojbJSON.Player.Name + ": " + (ojbJSON.Enemy.MyWeapon.WeaponDamage - ojbJSON.Player.MyArmour.DamageReduction);
            index++;
        } else {
            ResposeLines[index] = "Damage on " + ojbJSON.Player.Name + ": 0";
            index++;
        }
        //Fight back.
        ResposeLines[index] = ojbJSON.Player.Name + " hit's " + ojbJSON.Enemy.Name;
        index++;
        if (ojbJSON.PlayerHitEnemy) {
            ResposeLines[index] = "Succesfull hit!";
            index++;
            ResposeLines[index] = "Damage on " + ojbJSON.Enemy.Name + ": " + (ojbJSON.Player.MyWeapon.WeaponDamage);
            index++;
        }
        else {
            ResposeLines[index] = "MISS!!!";
            index++;
        }
    }
    else {
        ResposeLines[index] = "MISS!!!";
        index++;
        //Fight back.
        ResposeLines[index] = ojbJSON.Player.Name + " hit's " + ojbJSON.Enemy.Name;
        index++;
        if (ojbJSON.PlayerHitEnemy) {
            ResposeLines[index] = "Succesfull hit!";
            index++;
            ResposeLines[index] = "Damage on " + ojbJSON.Enemy.Name + ": " + (ojbJSON.Player.MyWeapon.WeaponDamage);
            index++;
        }
        else {
            ResposeLines[index] = "MISS!!!";
            index++;
        }
    }
    return index;
}

function DisplayIfCharacterPoisoned(character, index) {
    if (character.Poisoned) {
        ResposeLines[index] = character.Name + " takes poison damage: " + character.PoisonDMGPerRound;
        index++;
        setTimeout(function () { AnimatePoisonDamage(character) }, IncriseMillisecoundsToWait * 10);

    }
    return index
}

// At the moment only enemy can be poisoned.
function AnimatePoisonDamage(character) {
    document.getElementById("LabelEnemy1HP").innerText = character.MaxHealthPoint + '/' + character.ActualHealthPoint;
    $('#LabelEnemy1HP').css('background', 'Red'); 
    $('#tdEnemyHP').css('background-color', 'Red');
    setTimeout(function () { $("#LabelEnemy1HP").css('background', 'initial') }, IncriseMillisecoundsToWait);
    setTimeout(function () { $('#tdEnemyHP').css('background-color', 'initial'); }, IncriseMillisecoundsToWait);
    var audioPoisonHurt = new Audio('Music/HumanHurt.mp3');
    audioPoisonHurt.play();
}

//Displayes one line from the Responseline array and calls NextRound() after the last line
//and sets the music and contorpanel disabled if the the whole battle is finished.
function DisplayFight() {
    var DivDisplay = document.getElementById("DivDisplayFight");

    if (DisplayLine < ResposeLines.length) {
        DivDisplay.innerHTML += "<h2>" + ResposeLines[DisplayLine] + "</h2>";
        DisplayLine++;
        DivDisplay.scrollBy(0, 100);
    }
    if (DisplayLine == ResposeLines.length) {
        clearInterval(IDDisplayFight);
        $("#lblStopButtonMSG").text('');
        $("#btnStopFight").prop('disabled', false);
        $("#btnStopFight").fadeTo(0, 1);
        RoundNumber++;
        if (!Paused && ResponseObj.Player.Alive && ResponseObj.Enemy.Alive) {
            NextRound();
        }
    }
}

function DisplayLastRound() {
    var DivDisplay = document.getElementById("DivDisplayFight");

    if (DisplayLine < ResposeLines.length) {
        DivDisplay.innerHTML += "<h2>" + ResposeLines[DisplayLine] + "</h2>";
        DisplayLine++;
        DivDisplay.scrollBy(0, 100);
    }
    if (DisplayLine == ResposeLines.length) {
        clearInterval(IDDisplayFight);
        $("#lblStopButtonMSG").text('');
    }
}


//Stops or restarts calling NextRound() function.
function ButtonClicked() {

    Paused = !Paused;

    if (Paused) {
        $("#btnStopFight").prop('disabled', true);
        $("#btnStopFight").fadeTo(0, 0.3);
        $("#btnStopFight").val('CONTINUE');
        $("#lblStopButtonMSG").text('Fight will stop on the end of the round!');
    }
    if (!Paused) {
        $("#btnStopFight").val('Stop Fight');
        NextRound();
    }
}

//Increase the the speed of display by changeing a global var IncriseMillisecoundsToWait,
//so it will incrise the speed of every function what uses this variable. Then restart displaying.
function SpeedUpp() {
    if (IncriseMillisecoundsToWait > 200) {
        IncriseMillisecoundsToWait -= 200;
        clearInterval(IDDisplayFight);
        if (ResponseObj.Player.Alive && ResponseObj.Enemy.Alive) {
            IDDisplayFight = setInterval(function () { DisplayFight(); }, IncriseMillisecoundsToWait);
        }
        else {
            IDDisplayFight = DisplayFightLastRoundWithEndAnimations();
        }
    }
}

//Decrease the the speed of display by changeing a global var IncriseMillisecoundsToWait,
//so it will decrease the speed of every function what uses this variable. Then restart displaying.
function SlowDown() {
    if (IncriseMillisecoundsToWait < 5000) {
        IncriseMillisecoundsToWait += 200;
        clearInterval(IDDisplayFight);
        if (ResponseObj.Player.Alive && ResponseObj.Enemy.Alive) {
            IDDisplayFight = setInterval(function () { DisplayFight(); }, IncriseMillisecoundsToWait);
        }
        else {
            IDDisplayFight = DisplayFightLastRoundWithEndAnimations();
        }
    }
}

//Displaying and timeing the animatitons to represent fight actions.
function PlayFightAnimations(ojbJSON) {

    if (ojbJSON.Player.Initiation >= ojbJSON.Enemy.Initiation) {
        if (ojbJSON.PlayerHitEnemy) {
            setTimeout(function () { AnimatePlayerHitEnemy(ojbJSON.Enemy); }, IncriseMillisecoundsToWait * 3);
        }
        if (ojbJSON.EnemyHitPlayer) {
            setTimeout(function () { AnimateEnemyHitPlayer(ojbJSON.Player); }, IncriseMillisecoundsToWait * 6);
        }
    } else {
        if (ojbJSON.EnemyHitPlayer) {
            setTimeout(function () { AnimateEnemyHitPlayer(ojbJSON.Player); }, IncriseMillisecoundsToWait * 3);
        }
        if (ojbJSON.PlayerHitEnemy) {
            setTimeout(function () { AnimatePlayerHitEnemy(ojbJSON.Enemy); }, IncriseMillisecoundsToWait * 6);
        }
    }
}

//The animations what hapens if Player hits the Enemy.
function AnimatePlayerHitEnemy(enemy) {
    let windowWidth = $(window).width() * 0.8;
    //Animations.
    $("#PlayerImage").animate({ left: windowWidth.toString() + 'px' }, IncriseMillisecoundsToWait);
    $("#ImageEnemy1").animate({ opacity: '0.3' }, IncriseMillisecoundsToWait);
    $("#tblEnemey").css('background-color', 'red');
    //Music.
    var audioSuccesfullHit = new Audio('Music/Axe.mp3');
    setTimeout(function () { audioSuccesfullHit.play(); }, IncriseMillisecoundsToWait);
    //Set EnemyHp.
    if (!enemy.Poisoned) {
        document.getElementById("LabelEnemy1HP").innerText = enemy.MaxHealthPoint + '/' + enemy.ActualHealthPoint;
    } else {
        if (enemy.ActualHealthPoint > 0) {
            document.getElementById("LabelEnemy1HP").innerText = enemy.MaxHealthPoint + '/' + (enemy.ActualHealthPoint + enemy.PoisonDMGPerRound);
        }
        else {
            document.getElementById("LabelEnemy1HP").innerText = enemy.MaxHealthPoint + '/' + enemy.ActualHealthPoint;
        }
        
    }
    //Restore the animations.
    $("#PlayerImage").animate({ left: '0px' }, IncriseMillisecoundsToWait);
    $("#ImageEnemy1").animate({ opacity: '1' }, IncriseMillisecoundsToWait);
    setTimeout(function () { $("#tblEnemey").css('background-color', 'initial'); }, IncriseMillisecoundsToWait * 2);
}

//The animations what happens if Enemy hits the Player.
function AnimateEnemyHitPlayer(player) {
    let windowWidth = $(window).width() * 0.8;
    //Animations.
    $("#ImageEnemy1").animate({ right: windowWidth.toString() + 'px' }, IncriseMillisecoundsToWait);
    $("#PlayerImage").animate({ opacity: '0.3' }, IncriseMillisecoundsToWait);
    $("#tblPlayer").css('background-color', 'red');
    //Music.
    var audioSuccesfullHit = new Audio('Music/Axe.mp3');
    setTimeout(function () { audioSuccesfullHit.play(); }, IncriseMillisecoundsToWait);
    //Set PlayerHp.
    document.getElementById("LabelCharacterHP").innerText = player.MaxHealthPoint + '/' + player.ActualHealthPoint;
    //Restore the animations.
    $("#ImageEnemy1").animate({ right: '0px' }, IncriseMillisecoundsToWait);
    $("#PlayerImage").animate({ opacity: '1' }, IncriseMillisecoundsToWait);
    setTimeout(function () { $("#tblPlayer").css('background-color', 'initial'); }, IncriseMillisecoundsToWait * 2);
}

//Audio is fadeing out on the very end of battle. $(audio1).animate({volume:0}, 3000) didn't work.
//It should work in cycle...
function FadeOutAudio() {
    $('#audMusic').animate({ volume: 0 }, 3000);
}

//Fadeing out and disabeling the control panel. We use it before and after fight.
function FadeOutControlPanel() {
    $("#btnStopFight").prop('disabled', true);
    $("#btnSpeedUp").prop('disabled', true);
    $("#btnSlowDown").prop('disabled', true);
    $("#btnStopFight").fadeTo("slow", 0.3);
    $("#btnSpeedUp").fadeTo("slow", 0.3);
    $("#btnSlowDown").fadeTo("slow", 0.3);
}

//Displayes the animations if Player wins.
function AnimationPlayerWins() {
    let myWidth = document.getElementById('PlayerImage').offsetWidth;
    myWidth = myWidth * 2;
    let myHeight = document.getElementById('PlayerImage').offsetHeight;
    myHeight = myHeight * 2;

    $('#PlayerImage').animate({
        left: '120',
        top: '170',
        width: myWidth + 'px',
        height: myHeight + 'px'
    }, "slow");
    //Show DivFinishBattle and write result.
    $('#DivFinishBattle').show();
    $('#DivFinishBattle').html('<h1>YOU WON THE BATTLE!!!</h1>');
    $('#tblPlayer').hide();
}

//Displayes the animations if Enemy wins.
function AnimationEnemyWins() {
    let myWidth = document.getElementById('ImageEnemy1').offsetWidth;
    myWidth = myWidth * 2;
    let myHeight = document.getElementById('ImageEnemy1').offsetHeight;
    myHeight = myHeight * 2;
    $('#ImageEnemy1').animate({
        right: '100',
        top: '220',
        width: myWidth + 'px',
        height: myHeight + 'px'
    }, "slow");
    //Show DivFinishBattle and write result.
    $('#DivFinishBattle').show();
    $('#DivFinishBattle').html('<h1>THE ENEMY WON THE BATTLE!!!</h1>');
    $('#tblEnemey').hide();
}

function CreateAndDisplayBtnContinueGame() {
    document.getElementById("tblControlPanel").rows[1].cells[0].innerHTML =
        '<input type="button"  id="btnContinueGame" Value="Continue Game" onclick="RedirectToBattleFinishedPage()"/>';
}

function RedirectToBattleFinishedPage() {
    location.replace("BattleFinished.aspx");
}


$(document).keyup(function (e) {
    var btnStopFightisDisabled = $('#btnStopFight').prop('disabled');
    if (!btnStopFightisDisabled) {
        ButtonClicked();
    }
});
