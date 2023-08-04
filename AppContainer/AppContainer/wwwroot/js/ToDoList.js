
(() => {
    let toDoListArray = [];
    const form = document.querySelector(".form");
    const input = form.querySelector(".form__input");
    const ul = document.querySelector(".toDoList");

    form.addEventListener('submit', e => {
        e.preventDefault();

        let add = {
            ToDoListItem: input.value

        }
        $.ajax({
            type: "post",
            url: "/ToDoList/Create",
            data: add,
            success: function (result) {


                let itemId = result.id;
                let toDoItem = result.toDoListItem
                addItemToDOM(itemId, toDoItem);
                addItemToArray(itemId, toDoItem);
                input.value = '';

            }
        });



    });

    ul.addEventListener('click', e => {
        let id = e.target.getAttribute('data-id');
        removeItemFromDOM(id);
        removeItemFromArray(id);
        deleteItemWithAjax(id);
    });

    function addItemToDOM(itemId, toDoItem) {
        const li = document.createElement('li');
        li.setAttribute("data-id", itemId);
        li.innerText = toDoItem;
        ul.appendChild(li);


        li.addEventListener("click", e => {
            let id = e.target.getAttribute("data-id");
            if (id) {
                deleteItemWithAjax(id);
            }
        });
        ul.appendChild(li);
    }
    function deleteItemWithAjax(itemId) {
        $.ajax({
            type: "post",
            url: "/ToDoList/Delete", 
            data: { id: itemId },
            success: function (result) {
                if (result.success) {
                   
                    removeItemFromDOM(itemId);
                    removeItemFromArray(itemId);

                } else {
                    alert("Silme işlemi başarısız oldu.");
                }
            },

        });
    }

    function addItemToArray(itemId, toDoItem) {
        toDoListArray.push({ itemId, toDoItem });
        console.log(toDoListArray)
    }

    function removeItemFromDOM(id) {
        var li = document.querySelector('[data-id="' + id + '"]');
        ul.removeChild(li);
    }

    function removeItemFromArray(id) {
        toDoListArray = toDoListArray.filter(item => item.itemId !== id);
        console.log(toDoListArray);
    }

})();