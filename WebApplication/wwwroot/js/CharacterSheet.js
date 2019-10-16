window.onload = function () {
    setupTrainingDropdowns();
};

function setupTrainingDropdowns() {
    var ut = document.createElement('option');
    ut.value = 'Untrained';
    ut.innerText = 'Untrained';
    var t = document.createElement('option');
    t.value = 'Trained';
    t.innerText = 'Trained';
    var e = document.createElement('option');
    e.value = 'Expert';
    e.innerText = 'Expert';
    var m = document.createElement('option');
    m.value = 'Master';
    m.innerText = 'Master';
    var l = document.createElement('option');
    l.value = 'Legendary';
    l.innerText = 'Legendary';

    var sel = $('select[id$=training]');
    for (i = 0; i < sel.length; i++) {
        sel[i].appendChild(ut);
        sel[i].appendChild(t);
        sel[i].appendChild(e);
        sel[i].appendChild(m);
        sel[i].appendChild(l);
    }
}

function updateProficiency(target, trigger) {
    var field = $('#' + target);
    var training = $('#' + trigger);
    var level = $('#level').val();
    level = parseInt(level);
    if (training.val() == 'Untrained') {
        field.val(0);
    } else if (training.val() == 'Trained') {
        field.val(2 + level);
    } else if (training.val() == 'Expert') {
        field.val(4 + level);
    } else if (training.val() == 'Master') {
        field.val(6 + level);
    } else if (training.val() == 'Legendary') {
        field.val(8 + level);
    }
}

function abilityScoreSave() {
    var str = $('input[id^="strength"]');
    var dex = $('input[id^="dexterity"]');
    var con = $('input[id^="constitution"]');
    var int = $('input[id^="intelligence"]');
    var wis = $('input[id^="wisdom"]');
    var cha = $('input[id^="charisma"]');

    var strscore = parseInt(str[2].value);
    var dexscore = parseInt(dex[2].value);
    var conscore = parseInt(con[2].value);
    var intscore = parseInt(int[2].value);
    var wisscore = parseInt(wis[2].value);
    var chascore = parseInt(cha[2].value);

    //str
    for (i = 3; i < str.length; i++) {
        if (str[i].checked) {
            if (str[i].id.includes("flaw")) {
                strscore -= 2;
            }
            else if (strscore < 18) {
                strscore += 2;
            } else {
                strscore += 1;
            }
        }
    }
    //dex
    for (i = 3; i < dex.length; i++) {
        if (dex[i].checked) {
            if (dex[i].id.includes("flaw")) {
                dexscore -= 2;
            }
            else if (dexscore < 18) {
                dexscore += 2;
            } else {
                dexscore += 1;
            }
        }
    }
    //con
    for (i = 3; i < con.length; i++) {
        if (con[i].checked) {
            if (con[i].id.includes("flaw")) {
                conscore -= 2;
            }
            else if (conscore < 18) {
                conscore += 2;
            } else {
                conscore += 1;
            }
        }
    }
    //int
    for (i = 3; i < int.length; i++) {
        if (int[i].checked) {
            if (int[i].id.includes("flaw")) {
                intscore -= 2;
            }
            else if (intscore < 18) {
                intscore += 2;
            } else {
                intscore += 1;
            }
        }
    }
    //wis
    for (i = 3; i < wis.length; i++) {
        if (wis[i].checked) {
            if (wis[i].id.includes("flaw")) {
                wisscore -= 2;
            }
            else if (wisscore < 18) {
                wisscore += 2;
            } else {
                wisscore += 1;
            }
        }
    }
    //cha
    for (i = 3; i < cha.length; i++) {
        if (cha[i].checked) {
            if (cha[i].id.includes("flaw")) {
                chascore -= 2;
            }
            else if (chascore < 18) {
                chascore += 2;
            } else {
                chascore += 1;
            }
        }
    }

    str[0].value = strscore;
    dex[0].value = dexscore;
    con[0].value = conscore;
    int[0].value = intscore;
    wis[0].value = wisscore;
    cha[0].value = chascore;

    str[1].value = Math.floor((strscore - 10) / 2);
    dex[1].value = Math.floor((dexscore - 10) / 2);
    con[1].value = Math.floor((conscore - 10) / 2);
    int[1].value = Math.floor((intscore - 10) / 2);
    wis[1].value = Math.floor((wisscore - 10) / 2);
    cha[1].value = Math.floor((chascore - 10) / 2);
}

function abilityBaseChange() {
    var bases = $('.ability-score-base');

    var background = $('.ability-score-checkbox[id*="background"]');
    var classboost = $('.ability-score-checkbox[id*="class"]');
    var levelone = $('.ability-score-checkbox[id*="01"]');

    var allten = true;

    for (b = 0; b < bases.length; b++) {
        if (bases[b].value !== "10") {
            allten = false;
        }
    }

    if (!allten) {
        for (i = 0; i < background.length; i++) {
            background[i].checked = false;
            background[i].disabled = true;
        }

        for (i = 0; i < classboost.length; i++) {
            classboost[i].checked = false;
            classboost[i].disabled = true;
        }

        for (i = 0; i < levelone.length; i++) {
            levelone[i].checked = false;
            levelone[i].disabled = true;
        }
    } else {
        for (i = 0; i < background.length; i++) {
            background[i].disabled = false;
        }

        for (i = 0; i < classboost.length; i++) {
            classboost[i].disabled = false;
        }

        for (i = 0; i < levelone.length; i++) {
            levelone[i].disabled = false;
        }
    }
}