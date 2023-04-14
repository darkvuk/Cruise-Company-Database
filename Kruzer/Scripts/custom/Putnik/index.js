function deletePutnik(x) {
    if (confirm("Da li ste sigurni?")) {
        let url = `https://localhost:44389/Putnik/DeletePutnik/${x}`;
        window.location.href = url;
    }
}