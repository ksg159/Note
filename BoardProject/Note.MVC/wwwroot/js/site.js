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
})

