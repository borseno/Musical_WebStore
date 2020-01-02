    var btns = document.querySelectorAll('.btnUku');
    var strings = document.querySelectorAll('.string');
    var tracks = document.querySelectorAll('.anotherAudio');
    var tuners = document.querySelectorAll('.tuner');

    btns.forEach(btnUku => btnUku.addEventListener('click', playString));

function playString(ev) {
    var track = document.querySelector("#" + this.dataset.note);
    var string = document.querySelector(".string." + this.dataset.note);
    var tun = document.querySelector(".tuner." + this.dataset.note);

    if (this.classList.contains('active')) {
        btns.forEach(btnUku => btnUku.classList.remove('active'));
        strings.forEach(string => string.classList.remove('active'));
        tuners.forEach(tuner => tuner.classList.remove('active'));
        pauseTracks();
    } else {
        btns.forEach(btnUku => btnUku.classList.remove('active'));
        strings.forEach(string => string.classList.remove('active'));
        tuners.forEach(tuner => tuner.classList.remove('active'));
        string.classList.add('active');
        tun.classList.add('active');
        this.classList.add('active');

        if (track) {
            pauseTracks();
            track.currentTime = 0;
            track.play();
        }
    }
}

function pauseTracks() {
    tracks.forEach(track => track.pause());
}

