function changeEnabledButton(id) {

    console.log(id);

    let navBut = document.getElementById(id);

    console.log(navBut.classList[0]);

    removeEnabledFromAll();

    navBut.classList.add("enabled");
}

function removeEnabledFromAll() {
    let mainBut = document.getElementById("mainlink");
    let favoriteBut = document.getElementById("favoritelink");
    let profileBut = document.getElementById("profilelink");

    mainBut.classList.remove("enabled");
    favoriteBut.classList.remove("enabled");
    profileBut.classList.remove("enabled");
}