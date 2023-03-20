$(document).ready(
    $('#favoriteCheckbox').click(() => {
        if ($('#favoriteCheckbox').is(':checked')) {
            $('#contactList').load('/Contact/FavoriteContactList')
        } else {
            $('#contactList').load("/Contact/ContactList")
        }
    }
    )
)