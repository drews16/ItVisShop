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