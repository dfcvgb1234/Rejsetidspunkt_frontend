
let progressBar;

function AddProgressbar() {
    progressBar = new CircleProgress(".progress", {
        max: 100,
        value: 100,
        textFormat: "none"
    });
}

function updateProgress(value, progressText) {
    //console.log("new ProgressValue:" + value);
    progressBar.value = value;
    progressBar.textFormat = function (value, max) {
        return progressText;
    }
}

// Initialize and add the map
let map;

async function initMap(lat, lon, locationName) {

    console.log("Lat: " + lat + " | Lon:" + lon);
    const position = { lat: lat, lng: lon };
    const { Map } = await google.maps.importLibrary("maps");
    const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");

    // The map, centered at Uluru
    map = new Map(document.getElementById("map"), {
        zoom: 15,
        center: position,
        mapId: "MainMap",
        disableDefaultUI: true
    });

    // The marker, positioned at Uluru
    const marker = new AdvancedMarkerElement({
        map: map,
        position: position,
        title: locationName,
    });
}

function updateTimingText(walkTime, cycleTime) {
    console.log(walkTime + " : " + cycleTime);

    const walkText = document.getElementById("walk-time");
    const cycleText = document.getElementById("cycle-time");

    walkText.innerText = walkTime;
    cycleText.innerText = cycleTime;
}

function fillUIInfo(departureDirection, imageSource, departureStation, departureTime) {
    const direction = document.getElementById("info-departuredirection");
    const image = document.getElementById("departure-image");
    const station = document.getElementById("info-departurestation");
    const time = document.getElementById("info-departuretime");

    direction.innerText = departureDirection;
    image.src = imageSource;
    station.innerText = departureStation;
    time.innerText = departureTime;
}

function addOptionToSelect(id, value, text) {
    const select = document.getElementById(id);

    select.innerHTML += '<option value="' + value + '">' + text + "</option>";
}

function getSelectValue(id) {
    const select = document.getElementById(id);

    return select.value;
}

function clearSelect(id) {
    const select = document.getElementById(id);

    select.innerHTML = "";
}