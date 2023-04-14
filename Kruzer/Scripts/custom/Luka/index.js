function deleteLuka(id) {
    if (confirm("Da li ste sigurni?")) {
        let url = `${window.location.protocol}//${window.location.host}/Luka/DeleteLuka/${id}`;
        window.location.href = url;
        console.log('izvrseno');
    }
}