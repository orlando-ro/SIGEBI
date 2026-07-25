// ==========================================
// SISTEMA GLOBAL DE CARRITO Y NOTIFICACIONES
// ==========================================

// 1. Inyectar contenedor de notificaciones automáticamente si no existe
document.addEventListener("DOMContentLoaded", function () {
    if (!document.getElementById("toastContenedorGlobal")) {
        const toastHTML = `
            <div id="toastContenedorGlobal" class="position-fixed bottom-0 end-0 p-3" style="z-index: 1080;">
                <div id="toastNotificacion" class="toast align-items-center text-white border-0 shadow-lg" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="3000">
                    <div class="d-flex">
                        <div class="toast-body fw-semibold fs-6" id="toastMensaje"></div>
                        <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                </div>
            </div>
        `;
        document.body.insertAdjacentHTML('beforeend', toastHTML);
    }
});

// 2. Función global para mostrar Notificaciones (Toast de Bootstrap)
function mostrarNotificacion(mensajeHtml, claseColor) {
    const toastEl = document.getElementById('toastNotificacion');
    const toastMensaje = document.getElementById('toastMensaje');

    if (!toastEl || !toastMensaje) return;

    // Limpiar clases de color anteriores
    toastEl.className = 'toast align-items-center border-0 shadow-lg ' + claseColor;

    // Manejar color del botón de cierre (oscuro para fondo amarillo/claro)
    const btnClose = toastEl.querySelector('.btn-close');
    if (claseColor.includes('text-dark')) {
        btnClose.classList.remove('btn-close-white');
    } else {
        btnClose.classList.add('btn-close-white');
    }

    // Establecer el mensaje y mostrar
    toastMensaje.innerHTML = mensajeHtml;
    const toast = new bootstrap.Toast(toastEl);
    toast.show();
}

// 3. Función global para copiar el ISBN al portapapeles
function copiarIsbn(isbn) {
    navigator.clipboard.writeText(isbn).then(() => {
        mostrarNotificacion('<i class="bi bi-clipboard-check me-2"></i> ISBN Copiado exitosamente', 'bg-success');
    }).catch(err => {
        mostrarNotificacion('<i class="bi bi-exclamation-triangle me-2"></i> Error al copiar el ISBN', 'bg-danger');
        console.error('Error al copiar: ', err);
    });
}

// 4. Función global para agregar el libro a la memoria local (Carrito de Solicitudes)
function agregarAlCarrito(isbn, titulo) {
    // Leer el carrito actual o crear un arreglo vacío si no existe
    let carrito = JSON.parse(localStorage.getItem('sigebi_carrito_solicitudes')) || [];

    // Verificar si el libro ya fue agregado previamente
    let existe = carrito.find(libro => libro.isbn === isbn);

    if (existe) {
        mostrarNotificacion('<i class="bi bi-info-circle me-2"></i> Este recurso ya está en tu lista de solicitudes.', 'bg-warning text-dark');
        return;
    }

    // Agregar el nuevo libro al arreglo
    carrito.push({ isbn: isbn, titulo: titulo });

    // Guardar el arreglo actualizado en el navegador
    localStorage.setItem('sigebi_carrito_solicitudes', JSON.stringify(carrito));

    mostrarNotificacion('<i class="bi bi-cart-plus me-2"></i> ¡Libro agregado a tus solicitudes!', 'bg-primary');
}