//const account = document.getElementById("account");
//const loginModal = document.getElementById("account-modal");
//const closeModalBtn = document.querySelector(".modal__close");

//account.onclick = () => {
//    loginModal.classList.add("modal__active");

//    closeModalBtn.addEventListener("click", closeLoginModal);
//    loginModal.addEventListener("click", hideLoginModal);

//    function closeLoginModal() {
//        loginModal.classList.remove("modal__active")
//        closeModalBtn.removeEventListener("click", closeLoginModal);
//        loginModal.removeEventListener("click", hideLoginModal);
//    }
        
//    function hideLoginModal(event) {
//        if (event.target === loginModal) {
//            closeLoginModal();
//        }
//    }
//};

function showSearchPanel() {
    document.querySelector(".search-panel").classList.toggle("show");
}

/********************
    Home Slider.
 *******************/
const homeSwiper = new Swiper(".home-swiper", {
    direction: "horizontal",
    loop: true,

    autoplay: {
        delay: 5000,
    },

    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },

    pagination: {
        el: ".swiper-pagination",
    },
});

/**************************
    Product details.
 *************************/
const productDetailsSwiper = new Swiper(".details_swiper", {
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