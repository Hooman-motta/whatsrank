let editKey = "isEdit";

function ajaxBegin() {
    showLoading();
}

function ajaxFailure(xhr) {
    hideLoading();
}

//-----------
// --- user
//-----------
function ajaxCmpAuth(xhr) {
    const { errors, data } = JSON.parse(xhr.responseText);
    if (xhr.status === 200) {
        location.href = data;
    }
    errors && errors.forEach(item => {
        notifyError(item.value);
    });
    // hideLoading();
}

// vote modal
function voteModal(el) {
    const cls = "voted";
    const value = el.getAttribute("data-value");
    el.parentNode.querySelectorAll("li")
        .forEach((item, index) => {
            if (index <= value) {
                item.classList.add(cls);
            }
            else {
                item.classList.remove(cls);
            }
        });
    let form = document.querySelector("#voteModalForm");
    if (typeof (form) != null && form != null) {
        form.querySelector("input[name=MarkValue]").value = value;
    }
}

function ajaxCmpVoteModal(xhr) {
    hideLoading();
    const { errors, data } = JSON.parse(xhr.responseText);
    if (xhr.status === 200) {
        let movieInfo = document.querySelector(".page-info");
        let { markValue, vote: { voteCount, displayVoteAverage } } = data;
        movieInfo.querySelector(".right button .text").innerHTML = "تغییر رای شما";
        movieInfo.querySelector(".right button .mark-value .your-vote").innerHTML = markValue;
        movieInfo.querySelector(".left .left-top .vote small b:last-child").innerHTML = `${voteCount} رای`;
        movieInfo.querySelector(".left .left-top .vote small b:first-child").innerHTML = displayVoteAverage;
        notifySuccess("رای شما با موفقیت ثبت شد.");
        $('#voteModal').modal('hide');
    }
    errors && errors.forEach(item => {
        notifyError(item.value);
    });
}

// vote select
function voteSelect(el) {
    const cls = "voted";
    let ul = el.parentNode;
    let value = el.getAttribute("data-value");
    ul.querySelectorAll("li")
        .forEach((item, index) => {
            if (index <= value) {
                item.classList.add(cls);
            }
            else {
                item.classList.remove(cls);
            }
        });
    let form = ul.querySelector(".form form");
    if (typeof (form) != null && form != null) {
        form.querySelector("input[name=markValue]").value = value;
    }
}

function ajaxCmpVoteSelect(xhr) {
    hideLoading();
    const { errors, data } = JSON.parse(xhr.responseText);
    if (xhr.status === 200) {
        let { markValue, helper, vote: { voteCount, voteAverage } } = data;
        let selectVote = document.querySelector(`.select-vote[data-item="${helper}"]`);
        selectVote.querySelector(".mark-value .your-vote").innerHTML = markValue;

        // hide dropdown
        var dropDown = selectVote.querySelector(".dropdown-toggle");
        $(dropDown).dropdown('toggle');

        selectVote.parentNode.querySelector(".bottom-box .vote .avg b").innerHTML = voteAverage;
        notifySuccess("رای شما با موفقیت ثبت شد.");
    }
    errors && errors.forEach(item => {
        notifyError(item.value);
    });
}

function ajaxCmpVoteOption(xhr) {
    hideLoading();
    const { errors, data } = JSON.parse(xhr.responseText);
    if (xhr.status === 200) {
        let attrName = "data-selected";
        let leftOptions = document.querySelector(".page-info .top-page .left .left-options");
        let oldSelected = leftOptions.querySelector(`ul li[${attrName}=True]`);
        if (oldSelected) {
            oldSelected.setAttribute(attrName, "False");
            let countTag = oldSelected.querySelector(".vote .vote-count");
            countTag.innerHTML = (parseInt(countTag.innerHTML) - 1);
        }
        let newSelected = leftOptions.querySelector(`ul li[data-option="${data}"]`);
        newSelected.setAttribute(attrName, "True");
        let countTag = newSelected.querySelector(".vote .vote-count");
        countTag.innerHTML = (parseInt(countTag.innerHTML) + 1);
        leftOptions.querySelector("form button").innerHTML = "تغییر رای شما";
        notifySuccess("رای شما با موفقیت ثبت شد.");
    }
    errors && errors.forEach(item => {
        notifyError(item.value);
    });
}

function ajaxCmpSetComment(xhr) {
    hideLoading();
    const { errors } = JSON.parse(xhr.responseText);
    if (xhr.status === 200) {
        document.querySelector(".comment-page form").reset();
        notifySuccess("نظر شما با موفقیت ثبت شد.");
    }
    errors && errors.forEach(item => {
        notifyError(item.value);
    });
}

// Filling the select tag, that is listening to another.
function ajaxSelect(el) {
    showLoading();
    let selectedValue = el.value;
    let target = document.getElementById(el.getAttribute("data-target"));
    let url = `${el.getAttribute("data-url")}&id=${selectedValue}`;
    target.innerHTML = "";
    if (!isNaN(selectedValue)) {
        try {
            fetch(url)
                .then(response => response.json())
                .then(result => {
                    result.forEach(cur => {
                        target.innerHTML += `<option value=${cur.value}>${cur.text}</option>`
                    });
                }).catch(err => {
                    // notifyError(err)
                });
        } catch (err) {
            target.innerHTML = "";
            // notifyError(err)
        }
        finally {
            hideLoading();
        }
    }
    else {
        hideLoading();
    }
}

$("body").on("click", ".switch-auth", function () {
    const modal = "#authModal";
    var url = `/account/auth?handler=${$(this).attr("data-handler")}`;
    let modalDialog = document.querySelector(`${modal} .modal-dialog`);
    $.ajax({
        url: url,
        success: function (data) {
            $(modal).modal("show");
            $(modalDialog).html(data);
        }
    });
});