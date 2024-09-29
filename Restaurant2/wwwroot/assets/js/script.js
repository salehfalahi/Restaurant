'use strict';

/**
 * PRELOAD
 */
const preloader = document.querySelector("[data-preaload]");

window.addEventListener("load", function () {
    if (preloader) {
        preloader.classList.add("loaded");
    }
    document.body.classList.add("loaded");
});

/**
 * add event listener on multiple elements
 */
const addEventOnElements = function (elements, eventType, callback) {
    for (let i = 0, len = elements.length; i < len; i++) {
        elements[i].addEventListener(eventType, callback);
    }
}

/**
 * NAVBAR
 */
const navbar = document.querySelector("[data-navbar]");
const navTogglers = document.querySelectorAll("[data-nav-toggler]");
const overlay = document.querySelector("[data-overlay]");

const toggleNavbar = function () {
    if (navbar) {
        navbar.classList.toggle("active");
    }
    if (overlay) {
        overlay.classList.toggle("active");
    }
    document.body.classList.toggle("nav-active");
}

addEventOnElements(navTogglers, "click", toggleNavbar);

/**
 * HEADER & BACK TOP BTN
 */
const header = document.querySelector("[data-header]");
const backTopBtn = document.querySelector("[data-back-top-btn]");

let lastScrollPos = 0;

const hideHeader = function () {
    const isScrollBottom = lastScrollPos < window.scrollY;
    if (isScrollBottom) {
        header.classList.add("hide");
    } else {
        header.classList.remove("hide");
    }
    lastScrollPos = window.scrollY;
}

window.addEventListener("scroll", function () {
    if (header && backTopBtn) {
        if (window.scrollY >= 50) {
            header.classList.add("active");
            backTopBtn.classList.add("active");
            hideHeader();
        } else {
            header.classList.remove("active");
            backTopBtn.classList.remove("active");
        }
    }
});

/**
 * HERO SLIDER
 */
const heroSlider = document.querySelector("[data-hero-slider]");
const heroSliderItems = document.querySelectorAll("[data-hero-slider-item]");
const heroSliderPrevBtn = document.querySelector("[data-prev-btn]");
const heroSliderNextBtn = document.querySelector("[data-next-btn]");

let currentSlidePos = 0;
let lastActiveSliderItem = heroSliderItems[0];

const updateSliderPos = function () {
    if (lastActiveSliderItem) {
        lastActiveSliderItem.classList.remove("active");
    }
    heroSliderItems[currentSlidePos].classList.add("active");
    lastActiveSliderItem = heroSliderItems[currentSlidePos];
}

const slideNext = function () {
    currentSlidePos = (currentSlidePos >= heroSliderItems.length - 1) ? 0 : currentSlidePos + 1;
    updateSliderPos();
}

heroSliderNextBtn.addEventListener("click", slideNext);

const slidePrev = function () {
    currentSlidePos = (currentSlidePos <= 0) ? heroSliderItems.length - 1 : currentSlidePos - 1;
    updateSliderPos();
}

heroSliderPrevBtn.addEventListener("click", slidePrev);

/**
 * auto slide
 */
let autoSlideInterval;

const autoSlide = function () {
    autoSlideInterval = setInterval(slideNext, 7000);
}

addEventOnElements([heroSliderNextBtn, heroSliderPrevBtn], "mouseover", function () {
    clearInterval(autoSlideInterval);
});

addEventOnElements([heroSliderNextBtn, heroSliderPrevBtn], "mouseout", autoSlide);

window.addEventListener("load", autoSlide);

/**
 * PARALLAX EFFECT
 */
const parallaxItems = document.querySelectorAll("[data-parallax-item]");

window.addEventListener("mousemove", function (event) {
    const x = (event.clientX / window.innerWidth * 10) - 5;
    const y = (event.clientY / window.innerHeight * 10) - 5;

    for (let i = 0, len = parallaxItems.length; i < len; i++) {
        const speed = Number(parallaxItems[i].dataset.parallaxSpeed);
        parallaxItems[i].style.transform = `translate3d(${x * speed}px, ${y * speed}px, 0px)`;
    }
});
