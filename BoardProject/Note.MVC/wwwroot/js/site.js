$(".editor").trumbowyg({
    lang: 'ko',
    btnsDef: {
        image: {
            dropdown: ['insertImage', 'upload'],
            ico: 'insertImage'
        }
    },
    btns: [
        ['viewHTML'],
        ['undo', 'redo'], 
        ['formatting'],
        ['strong', 'em', 'del'],
        ['superscript', 'subscript'],
        ['link'],
        ['insertImage'],
        'image',
        ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
        ['unorderedList', 'orderedList'],
        ['horizontalRule'],
        ['removeformat'],
        ['fullscreen']
    ]
});

$(".delete").click(function myfunction() {
    var confirm_value = document.createElement("input");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_value";

    if (confirm("정말 삭제하시겠습니까?")) {
        confirm_value.value = "Y";

    } else {
        alert("취소 되었습니다.");
        confirm_value.value = "N";

    }
    return document.forms.appendChild(confirm_value);
});

function hTest() {
    var text = document.getElementById("test1");
    text.innerText = "작성한 글이 없는 유저들";
}


$("#btn1").click(function cEvent() {
    event();
});


function js1() {
    var a2 = document.getElementById("a1");
    a2.innerText = "이걸로 바꿔버렸";
}

function event() {
    js1();
}

$("#IdValidBtn").click(function () {
    var id = $("#IdText").val();
    var RegisterBtn = $("#RegisterBtn")
    $.ajax({
        url: "/Account/Idvalid",
        type: "post",
        data: { idText: id },
        success: function (data) {
            if (data.success) {
                alert("중복된 아이디가 없습니다.");
                RegisterBtn.removeAttr("disabled");
            } else {
                alert("중복된 아이디가 있습니다.");
                RegisterBtn.attr("disabled", "disabled");
            }
        }
    });
});
