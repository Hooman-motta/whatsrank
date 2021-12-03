//-----------
// --- onload
//-----------
window.onload = function () {
    hideLoading();
    confColspan();
};

function confColspan() {
    document.querySelectorAll("[data-span]").forEach(item => {
        let table = item.parentNode.parentNode;
        let theadCount = table.querySelector("thead").rows[0].cells.length;
        item.innerHTML = `<td colspan="${theadCount}">اطلاعاتی وجود ندارد</td>`;
    });
}

//-----------
// --- form
//-----------
preventFormSubmit();
function preventFormSubmit() {
    let forms = document.querySelectorAll("form input");
    if (forms.length) {
        for (let i = 0; i < forms.length; i++) {
            forms[i].onkeypress = function (e) {
                var key = e.charCode || e.keyCode || 0;
                if (key == 13) {
                    e.preventDefault();
                }
            }
        }
    }
}

//-----------
// --- aside
//-----------
asideConfigure();
function asideConfigure() {
    try {
        let result = "";
        let path = location.pathname.split("/");
        path.shift();
        for (const item of path) {
            result += `/${item.toLowerCase()}`;
        }

        // get
        let anchorTag = document.querySelector(`#aside .accordion-item .accordion-body .nav-link[href^="${result}"]`);

        let parent = anchorTag.closest(".accordion-item")
        let button = parent.querySelector(".accordion-button");
        let collapse = parent.querySelector(".accordion-collapse");

        // set
        button.classList.remove("collapsed");
        button.setAttribute("aria-expanded", "true");
        collapse.classList.add("show");
        anchorTag.classList.add("active");
    } catch (err) {
        console.log("We have error on sidebar activation");
    }
}

//-----------
// --- add button title
//-----------
function btnTitle(myKey) {
    let title = "افزودن";
    let params = new URLSearchParams(location.search);
    const queryObj = Object.fromEntries(params.entries());

    // if `myKey` is exists in url
    if (myKey in queryObj) {
        // console.log("yes");
        title = queryObj[myKey];
        sessionStorage.setItem(myKey, title);
    }
    // if `myKey` is not exist in the urk
    else {
        if ((window.sessionStorage && window.sessionStorage.getItem(myKey))) {
            title = window.sessionStorage.getItem(myKey);
        }
    }
    title = title.replace("-", " ");
    document.querySelector(".table-container .table-container-header button").innerText = title;
}

//-----------
// --- modal
//-----------

// it will be changed, get el parameter
function setModalLG() {
    document.querySelector("#createModal .modal-dialog")
        .classList.add("modal-lg");
}

function setModalXL() {
    document.querySelector("#createModal .modal-dialog")
        .classList.add("modal-xl", "modal-dialog-scrollable");
}

function viewModalAsFile(el) {
    let content = "";
    let url = el.getAttribute("data-url");
    let type = el.getAttribute("data-type");
    let title = el.getAttribute("data-title");
    url = url ? `\\${url}` : "\\panel\\images\\no-image.png";
    switch (type) {
        case null:
        case "BITMAP":
            content = `<img src="${url}" class="rounded img-fluid" alt="${title}" />`;
            break;
        case "SOUND":
            content = `<audio controls class="d-block m-auto">
                        <source src="${url}" type="audio/mpeg">
                        <source src="${url}" type="audio/ogg">
                    </audio>`;
            break;
        default:
            break;
    }
    viewBaseModal(title, content);
}

function viewModalAsText(el) {
    let title = el.getAttribute("data-title");
    let body = el.getAttribute("data-body");
    viewBaseModal(title, body);
}

function viewBaseModal(title, body) {
    let modalTag = document.getElementById('layoutModal');
    var myModal = new bootstrap.Modal(modalTag, {
        keyboard: true
    });
    modalTag.querySelector(".modal-title").innerHTML = title;
    modalTag.querySelector(".modal-body").innerHTML = body;
    myModal.show();
}

//-----------
// --- loading
//-----------
function hideLoading() {
    let loadingTag = document.querySelector(".ploading");
    loadingTag.classList.add("hide");
}

function showLoading() {
    let loadingTag = document.querySelector(".ploading");
    loadingTag.classList.remove("hide");
}

//-----------
// --- notify
//-----------
function notifySuccess(text) {
    $.notify(text, "success");
}

function notifyError(text) {
    $.notify(text, "error");
}

//-----------
// --- editor
//-----------
function editor(el) {
    let input = el.querySelector('textarea');
    $(input).summernote({
        tabsize: 2,
        height: 250,
        placeholder: 'شرح...',
        toolbar: [
            ['style', ['bold', 'italic', 'underline', 'clear']],
            ['font', ['strikethrough']],
            ['fontname', ['fontname']],
            ['fontsize', ['fontsize']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['height', ['height']],
        ]
    });
}

//-----------
// --- datepicker
//-----------
function datePicker(el) {
    let datePickers = el
        .querySelectorAll("[data-picker]");
    for (const item of datePickers) {
        // data date
        let dataDate = item.querySelector("[data-date]");
        // container
        let _container = item.querySelector("[data-container]");
        // input
        let _field = dataDate.querySelector("input");
        let _resetTrigger = dataDate.querySelector("[data-trigger] .reset");
        let _chooseTrigger = dataDate.querySelector("[data-trigger] .choose");
        let dateValue = _field.value ? _field.value : null;
        let myPickDate = new Pikaday({
            firstDay: 1,
            bound: true,
            format: 'jYYYY-jMM-jDD',
            yearRange: [1930, 2050],
            field: _field,
            container: _container,
            trigger: _chooseTrigger,
            onSelect: function () {
                // var date = document.createTextNode(this.getMoment().format('YYYY-MM-DD') + ' ');
                // _field.appendChild(date);
            }
        });
        myPickDate.setDate(dateValue);
        _resetTrigger.addEventListener("click", () => {
            myPickDate.setDate(null);
        });
    }
}

//-----------
// --- tags
//-----------
async function buildTags(el) {
    let arr = [];
    let input = el.querySelector('input');
    let url = el.getAttribute("data-tags");
    let response = await fetch(url);
    if (response.ok) {
        let json = await response.json();
        json.forEach(item => arr.push(`${item.id}-${item.title}`));
    } else {
        alert("HTTP-Error: " + response.status);
    }
    new Tagify(input, {
        whitelist: arr,
        maxTags: 10,
        dropdown: {
            maxItems: 20,           // <- mixumum allowed rendered suggestions
            classname: "tags-look", // <- custom classname for this dropdown, so it could be targeted
            enabled: 0,             // <- show suggestions on focus
            closeOnSelect: false    // <- do not hide the suggestions dropdown once an item has been selected
        },
        originalInputValueFormat: values => values.map(item => item.value).join(',')
    });
}