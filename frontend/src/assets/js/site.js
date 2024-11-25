document.querySelectorAll('.alert').forEach((alert) => {
  alert.addEventListener('closed.bs.alert', () => {
    console.log('Alert danger closed.');
  });
});
