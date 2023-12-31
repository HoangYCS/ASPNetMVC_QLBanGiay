const ul = document.querySelector(".ul-tag");
input = document.querySelector(".input-tag");
const slideSclick = $('.slide-show');
const listTag = $('.cdt-list-tag');
let listSize = [];
let listColor = [];
let listPrice = [];

function createTag(tags) {
    if (tags.length >= 2) {
        tags.push("Xóa tất cả");
    }
    TempTag = tags;
    ul.querySelectorAll("li").forEach(li => li.remove());
    tags.slice().reverse().forEach((tag, index) => {
        let liTag = `<li style="outline: #2be010 1px solid;">${tag}`;
        if (index === 0 && tags.length > 1) {
            liTag += ` <i class="uit uit-multiply" onclick="removeAllTags()"></i>`;
        } else {
            liTag += ` <i class="uit uit-multiply" onclick="removeTag(this, '${tag}')"></i>`;
        }
        liTag += "</li>";
        ul.insertAdjacentHTML("afterbegin", liTag);
    });
}

function removeTag(element, tag) {
    let index = TempTag.indexOf(tag);
    if (index > -1) {
        TempTag.splice(index, 1);
        if (TempTag.length === 0) {
            slideSclick.show();
            listTag.hide();
        }
    }

    if (TempTag.length === 2 && TempTag[TempTag.length - 1] === "Xóa tất cả") {
        TempTag.pop();
        createTag(TempTag);
    }

    if (listColor.includes(tag)) {
        let colorIndex = listColor.indexOf(tag);
        if (colorIndex > -1) {
            listColor.splice(colorIndex, 1);
        }
        $('.checkbox-item-color').prop('checked', false);

        listColor.forEach(color => {
            $(`.checkbox-item-color[value="${color}"]`).prop('checked', true);
        });
        $('#check-all-color').prop('checked', listColor.length === 0);
    }

    if (listSize.includes(tag)) {
        let sizeIndex = listSize.indexOf(tag);
        if (sizeIndex > -1) {
            listSize.splice(sizeIndex, 1);
        }
        $('.checkbox-item-size').prop('checked', false);

        listSize.forEach(size => {
            $(`.checkbox-item-size[value="${size}"]`).prop('checked', true);
        });
        $('#check-all-size').prop('checked', listSize.length === 0);
    }

    if (listPrice.includes(tag)) {
        let priceIndex = listPrice.indexOf(tag);
        if (priceIndex > -1) {
            listPrice.splice(priceIndex, 1);
        }
        $('.checkbox-item-price').prop('checked', false);
        listPrice.forEach(price => {
            $(`.checkbox-item-price[value="${price}"]`).prop('checked', true);
        });
        $('#check-all-price').prop('checked', listPrice.length === 0);
    }

    element.parentElement.remove();
}

function removeAllTags() {
    TempTag.length = 0;
    ul.querySelectorAll("li").forEach(li => li.remove());
    $('.checkbox-item-color').prop('checked', false);
    $('#check-all-color').prop('checked', true);
    $('.checkbox-item-size').prop('checked', false);
    $('#check-all-size').prop('checked', true);
    $('.checkbox-item-price').prop('checked', false);
    $('#check-all-price').prop('checked', true);
    slideSclick.show();
    listTag.hide();
}

$('.checkbox-item-size, .checkbox-item-color, .checkbox-item-price').on('change', function () {
    let listAll = [];
    if (this.id === 'check-all-color') {
        $('.checkbox-item-color').prop('checked', false);
        $('#check-all-color').prop('checked', true);
    }
    else if (this.id === 'check-all-price') {
        $('.checkbox-item-price').prop('checked', false);
        $('#check-all-price').prop('checked', true);
    }
    else if (this.id === 'check-all-size') {
        $('.checkbox-item-size').prop('checked', false);
        $('#check-all-size').prop('checked', true);
    }

    listColor = $('.checkbox-item-color:checked').map(function () {
        return $(this).val();
    }).get().filter(item => item !== "on");

    listPrice = $('.checkbox-item-price:checked').map(function () {
        return $(this).val();
    }).get().filter(item => item !== "on");

    listSize = $('.checkbox-item-size:checked').map(function () {
        return $(this).val();
    }).get().filter(item => item !== "on");


   
    if (listPrice.length === 0) {
        $('#check-all-price').prop('checked', true);
    } else if (listPrice.length > 0) {
        $('#check-all-price').prop('checked', false);
    }

    if (listSize.length === 0) {
        $('#check-all-size').prop('checked', true);
    } else if (listSize.length > 0) {
        $('#check-all-size').prop('checked', false);
    }

    if (listColor.length === 0) {
        $('#check-all-color').prop('checked', true);
    } else if (listColor.length > 0) {
        $('#check-all-color').prop('checked', false);
    }
    listAll = [...listSize, ...listColor, ...listPrice];

    if (listAll.length) {
        slideSclick.hide();
        listTag.show();
        createTag(listAll);
    } else {
        slideSclick.show();
        listTag.hide();
        $('#check-all-size').prop('checked', true);
    }
});