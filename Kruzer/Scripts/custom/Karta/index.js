function deleteKarta(id) {
    if (confirm("Da li ste sigurni?")) {
        let url = `${window.location.protocol}//${window.location.host}/Karta/DeleteKarta/${id}`;
        window.location.href = url;
        console.log('izvrseno');
    }
}