const list = document.querySelectorAll('.list1'); function activeLink() {
    list.forEach((item) =>
        item.classList.remove('active'));
    this.classList.add('active');
}
list.forEach((item) =>
    item.addEventListener('click', activeLink));
function selectFirstItem() {
    // Lấy danh sách phần tử <li>
    const list = document.querySelectorAll('.list1');
    // Thêm lớp "active" cho phần tử đầu tiên
    list[0].classList.add('active');
}