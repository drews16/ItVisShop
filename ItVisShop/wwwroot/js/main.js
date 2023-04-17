if ($(document).height() <= $(window).height()) {
    $(".footer").addClass("footer-static");
}
else {
    $(".footer").removeClass("footer-static");
}

function showSearchPanel() {
    document.querySelector(".search-panel").classList.toggle("show");
}

$(document).ready(function () {
    const header = $('.header');

    let hambActive = false;
    let menuActive = false;

    setHeader();
    initMenu();

    $(window).on('resize', function () {
        setHeader();
    });

    $(document).on('scroll', function () {
        setHeader();
    });

    function setHeader() {
        if ($(window).scrollTop() > 100) {
            header.addClass('scrolled');
        }
        else {
            header.removeClass('scrolled');
        }
    }

    function initMenu() {
        if ($('.hamburger').length) {
            const hamb = $('.hamburger');

            hamb.on('click', function (e) {
                e.stopPropagation();;
                console.log(hamb);

                if (!menuActive) {

                    openMenu();

                    $(document).one('click', function cls(e) {
                        if ($(e.target).hasClass('mobile-menu')) {
                            $(document).one('click', cls);
                        }
                        else {
                            closeMenu();
                        }
                    });
                }
                else {
                    $('.menu').removeClass('active');
                    menuActive = false;
                }
            });

            if ($('.page-menu__item').length) {
                let items = $('.page-menu__item');

                items.each(function () {
                    let item = $(this);

                    item.on('click', function (e) {
                        if (item.hasClass('has-children')) {
                            e.preventDefault();
                            e.stopPropagation();

                            let subItem = item.find('> ul');

                            if (subItem.hasClass('active')) {
                                subItem.toggleClass('active');
                            }
                            else {
                                subItem.toggleClass('active');
                            }
                        }
                        else {
                            e.stopPropagation();  
                        }
                    });
                });
            }
        }
    }

    function openMenu() {
        let fs = $('.menu');
        fs.addClass('active');
        hambActive = true;
        menuActive = true;
    }

    function closeMenu() {
        let fs = $('.menu');
        fs.removeClass('active');
        hambActive = false;
        menuActive = false;
    }
});