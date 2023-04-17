// Details swiper.
const productDetailsSwiper = new Swiper(".details-swiper", {
    direction: "horizontal",
    loop: true,

    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },

    pagination: {
        el: ".swiper-pagination",
    },

    mousewhell: true,
});

// Details tabs.
const tabsHead = document.querySelectorAll(".tab-head__item");
const tabsContent = document.querySelectorAll(".tab-content__item");

tabsHead.forEach((tab, index) => {
    tab.addEventListener("click", () => {
        changeTab(index);
    });
});

function changeTab(index) {
    setActiveClass(tabsHead, index);
    setActiveClass(tabsContent, index);
}

function setActiveClass(arr, index) {
    for (let el of arr) {
        el.classList.remove("active");
    }

    arr[index].classList.add("active");
}

// Quantity block.
const inputValue = document.querySelector("#details-quantity__input");

function btnPlusClick() {
    let val = parseInt(inputValue.value, 10);

    if (val < inputValue.max) {
        val++;
        inputValue.setAttribute("value", val);
    }
}

function btnMinusClick() {
    let val = parseInt(inputValue.value, 10);

    if (val > 1) {
        val--;
        inputValue.setAttribute("value", val);
    }
}

// Not authorized modal.
const openNotAuthModalBtn = document?.getElementById('popups-not-authorized__btn');
const popupsNotAuth = document.getElementById('popups-not-authorized');
const closePopupsNotAuthBtn = document?.getElementById('popups-not-authorized__close');

openNotAuthModalBtn?.addEventListener('click', function () {
    popupsNotAuth.classList.add('active');
    document.body.append(popupsNotAuth);

    closePopupsNotAuthBtn?.addEventListener('click', function() {
        popupsNotAuth.classList.remove('active');
    });

    popupsNotAuth.addEventListener('click', function (e) {
        if (e.target === popupsNotAuth) {
            popupsNotAuth.classList.remove('active');
        }
    });
});


// Add in cart animation.
const addInCartBtn = document?.getElementById('AddCart');
const closePopupsBtn = document.getElementById('close-pupups-btn');

addInCartBtn?.addEventListener('click', function () {
    const detailsPopups = document.getElementById('details-popups-container');

    detailsPopups.classList.add('active');

    setTimeout(function () {
        detailsPopups.classList.remove('active');
    }, 3000);

    closePopupsBtn.addEventListener('click', function () {
        detailsPopups.classList.remove('active');
    });
});

