// onload
window.onload = function () {
    hideLoading();
};

// menu
let toggleMenu = () => {
    document.querySelector("#menu").classList.toggle("show");
};

// loading
function hideLoading() {
    let loadingTag = document.querySelector(".ploading");
    loadingTag.classList.add("hide");
}

function showLoading() {
    let loadingTag = document.querySelector(".ploading");
    loadingTag.classList.remove("hide");
}

// notify
function notifySuccess(text) {
    $.notify(text, "success");
}

function notifyError(text) {
    $.notify(text, "error");
}

// auto toggle menu
document.addEventListener('mouseup', (e) => {
    var menu = document.getElementById('menu');
    if (!menu.contains(e.target)) {
        menu.classList.remove("show");
    }
});

function swipperCount() {
    let width = window.innerWidth;
    console.log("with : ");
    console.log(width);
    if (width <= 576) {
        return 2;
    }
    else if (width <= 768) {
        return 3;
    }
    else if (width <= 992) {
        return 4;
    }
    return 6;
}

function crawlInList(el) {
    let value = el.value;
    let ancestor = el.parentNode.parentNode;
    let listGroup = ancestor.querySelector(".list-group");
    listGroup.querySelectorAll("li")
        .forEach(item => {
            let title = item.getAttribute("data-title");
            if (title.indexOf(value) > -1) {
                item.style.display = "";
            }
            else {
                item.style.display = "none";
            }
        });
}
