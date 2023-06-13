const wrapper = document.querySelector('.wrapper');
const loginLink = document.querySelector('.login-link');
const registerLink = document.querySelector('.register-link');
const btnPopup = document.querySelector('.btnLogin-popup');
const iconClose = document.querySelector('.icon-close');
registerLink.addEventListener('click', () => { wrapper.classList.add('active'); });
loginLink.addEventListener('click', () => { wrapper.classList.remove('active'); });
btnPopup.addEventListener('click', () => {
    wrapper.classList.add('active-popup');
    document.body.style.pointerEvents = 'none';
    document.querySelector('.popup-wrapper').style.pointerEvents = 'auto';
});
iconClose.addEventListener('click', () => {
    wrapper.classList.remove('active-popup');
    const list = document.querySelectorAll('.list1');

    list.forEach((item) =>
        item.classList.remove('active'));
    list[0].classList.add('active');
    document.body.style.pointerEvents = 'auto';
    createtoast1('1');
});