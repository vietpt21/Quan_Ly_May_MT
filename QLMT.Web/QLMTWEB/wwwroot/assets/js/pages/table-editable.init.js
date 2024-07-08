$(function() {
    var e = {};
    $(".table-edits tr").editable({
       
        edit: function(t) {
            $(".edit i", this).removeClass("fa-pencil-alt").addClass("fa-save").attr("title", "Save")
        },
        save: function(t) {
            $(".edit i", this).removeClass("fa-save").addClass("fa-pencil-alt").attr("title", "Edit"), this in e && (e[this].destroy(), delete e[this])
        },
        cancel: function(t) {
            $(".edit i", this).removeClass("fa-save").addClass("fa-pencil-alt").attr("title", "Edit"), this in e && (e[this].destroy(), delete e[this])
        }
    })
});
/*$(function () {
    var e = {}; // Object to store editable instances

    // Initialize inline editing for rows in table with class 'table-edits'
    $(".table-edits tr").editable({
        edit: function () {
            // When entering edit mode, update the edit button icon and title
            $(".edit i", this).removeClass("fa-pencil-alt").addClass("fa-save").attr("title", "Save");

            // Store this editable instance in 'e'
            e[this] = $(this).data('editableInstance');
        },
        save: function () {
            // When saving changes, update the edit button icon and title
            $(".edit i", this).removeClass("fa-save").addClass("fa-pencil-alt").attr("title", "Edit");

            // If this editable instance is stored in 'e', destroy it and remove from 'e'
            if (this in e) {
                e[this].destroy();
                delete e[this];
            }
        },
        cancel: function () {
            // When canceling edits, update the edit button icon and title
            $(".edit i", this).removeClass("fa-save").addClass("fa-pencil-alt").attr("title", "Edit");

            // If this editable instance is stored in 'e', destroy it and remove from 'e'
            if (this in e) {
                e[this].destroy();
                delete e[this];
            }
        }
    });
});
*/