// select
function ajaxSelect(el) {
    showLoading();
    let selectedValue = el.value;
    let target = document.getElementById(el.getAttribute("data-target"));
    let url = `${el.getAttribute("data-url")}&id=${selectedValue}`;
    target.innerHTML = "";

    console.log(url);
    if (!isNaN(selectedValue) && parseInt(selectedValue) !== 0) {
        try {
            fetch(url)
                .then(response => response.json())
                .then(result => {
                    result.forEach(cur => {
                        target.innerHTML += `<option value=${cur.value}>${cur.text}</option>`
                    });
                }).catch(err => {
                    notifyError(err)
                });
        } catch (err) {
            target.innerHTML = "";
            // notifyError(err)
            console.log(err);
        }
        finally {
            hideLoading();
        }
    }
    else {
        hideLoading();
    }
}

// checkbox
function ajaxCheckBox(el) {
    showLoading();
    let url = el.getAttribute("data-url");
    fetch(url)
        .then(response => response.text())
        .then(result => {
            hideLoading();
            notifySuccess(result);
        }).catch(err => {
            hideLoading();
            notifyError(err)
        });
}

// load partial 
function ajaxLoadPartialForm(el) {
    showLoading();
    let url = el.getAttribute("data-url");
    let title = el.getAttribute("data-title");
    let modalEl = document.getElementById("createModal");
    const dataCreate = modalEl.querySelector("#dataCreate");
    modalEl.querySelector(".modal-title").innerText = title;
    new bootstrap.Modal(modalEl).show();
    try {
        fetch(url).then((response) => response.text())
            .then((html) => {
                dataCreate.innerHTML = html;

                // this will be changed by pure js.
                $("form").removeData("validator");
                $("form").removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse("form");

                // data-picker
                if (dataCreate.querySelectorAll("[data-picker]")) {
                    datePicker(dataCreate);
                }

                // editor
                if (dataCreate.querySelector("[data-source]")) {
                    let sourceEl = dataCreate.querySelector("[data-source]");
                    editor(sourceEl);
                }

                // tag
                if (dataCreate.querySelector("[data-tags]")) {
                    let tagEl = dataCreate.querySelector("[data-tags]");
                    buildTags(tagEl);
                }

                hideLoading();
            }).catch((err) => {
                throw new err;
            });
    } catch (err) {
        console.log(err);
        hideLoading();
    }
}

// function ajaxBegin() {
//     showLoading();
// }

// function ajaxFailure(xhr) {
//     console.log("ajaxFailure...!");
//     notifyError(xhr.responseText);
//     hideLoading();
// }

// function ajaxCompleted(xhr, url) {
//     try {
//         showLoading();
//         if (xhr.status === 200) {
//             let el = document
//                 .getElementById("dataList");
//             loadPartialAsModal(url, el);
//             notifySuccess(xhr.responseText);
//         }
//         let modalEl = document.getElementById('createModal');
//         bootstrap.Modal.getInstance(modalEl).hide();
//     } catch (err) {
//         console.log(err);
//     }
//     finally {
//         hideLoading();
//     }
// }

    // data-ajax-complete
    // data-ajax-mode
    // data-ajax-confirm	

    // data-ajax-loading-duration	
    // data-ajax-loading	

    // data-ajax-begin
    // data-ajax-failure	
    // data-ajax-success	
    // data-ajax-update

    // let rqState = parseInt(xhr.getResponseHeader("rqstate"));
    // if (status === 200 && rqState === 1) {
    // function toggleButton(state) {
    //     document.querySelector("form[data-ajax] button[type=submit]").disabled = state;
    // }