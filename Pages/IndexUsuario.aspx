<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IndexUsuario.aspx.cs" Inherits="Veterinaria.Pages.IndexUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="script.js"></script>
    <link href="CSS/indexUsuario.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            $('.open-modal').on('click', function () {
                var animalId = $(this).data('id');
                var targetModal = $(this).data('bs-target');

                if (targetModal === '#clinicalHistoryModal') {
                    $.ajax({
                        url: 'GetClinicalHistory.aspx',  // La página o el controlador que devuelve el historial clínico
                        type: 'GET',
                        data: { id: animalId },
                        success: function (data) {
                            $('#clinicalHistoryModal #modalBodyContent').html(data);
                        },
                        error: function () {
                            $('#clinicalHistoryModal #modalBodyContent').html('<p>Ocurrió un error al cargar el historial clínico.</p>');
                        }
                    });
                } else if (targetModal === '#agendaCitaModal') {
                    $.ajax({
                        url: 'GetCitasMedicas.aspx',  // La página o el controlador que devuelve el formulario de agendar cita
                        type: 'GET',
                        data: { id: animalId },
                        success: function (data) {
                            $('#agendaCitaModal #modalBodyContent').html(data);
                        },
                        error: function () {
                            $('#agendaCitaModal #modalBodyContent').html('<p>Ocurrió un error al cargar el formulario de agendar cita.</p>');
                        }
                    });
                }
            });
        });
    </script>



</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Label ID="lblWelcome" runat="server" Text="Welcome, User!" Font-Size="Large" Font-Bold="true"></asp:Label>
    </div>

    <div class="row mt-4">
        <asp:Repeater ID="rptAnimals" runat="server">
            <ItemTemplate>
                <div class="col-md-3 mb-4">
                    <div class="card animal-card">
                        <img src='<%# Eval("Ruta_imagen") %>' class="card-img-top custom-card-img" alt='<%# Eval("Raza") %>'>
                        <div class="card-body">
                            <h5 class="card-title mb-2 animal-alias"><%# Eval("alias") %></h5>
                            <p class="card-text animal-info">
                                <strong>Especie:</strong> <%# Eval("especie") %><br>
                                <strong>Raza:</strong> <%# Eval("raza") %><br>
                                <strong>Color de Pelo:</strong> <%# Eval("colorPelo") %><br>
                                <strong>Fecha de Nacimiento:</strong> <%# Eval("fechaNacimiento", "{0:dd/MM/yyyy}") %><br>
                                <strong>Peso Actual:</strong> <%# Eval("pesoActual") %> kg
                            </p>
                            <div class="d-flex justify-content-between align-items-center">
                                <button type="button" class="btn btn-primary open-modal" data-id='<%# Eval("id") %>' data-bs-toggle="modal" data-bs-target="#clinicalHistoryModal">
                                    Ver Historial Clínico
                                </button>
                                <button type="button" class="btn btn-success open-modal" data-id='<%# Eval("id") %>' data-bs-toggle="modal" data-bs-target="#agendaCitaModal">
                                    Agendar Cita
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>




    <!-- Modal -->
    <div class="modal fade" id="clinicalHistoryModal" tabindex="-1" aria-labelledby="clinicalHistoryModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="clinicalHistoryModalLabel">Historial Clínico</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div id="modalBodyContent">
                        <!-- Aquí se cargará el historial clínico -->
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal para Agendar Cita -->
    <div class="modal fade" id="agendaCitaModal" tabindex="-1" aria-labelledby="agendaCitaModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="agendaCitaModalLabel">Agendar Cita</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div id="modalBodyContent">
                        <!-- Aquí se cargará el formulario para agendar cita -->
                    </div>
                </div>
            </div>
        </div>
    </div>





    <div class="row mt-4">
        <div class="col-md-12 text-center">
            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                Agregar Mascota
            </button>
        </div>
    </div>

    <!-- Button trigger modal -->


    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Agregar Mascota</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="txtCodigo" class="form-label">Código:</label>
                                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="El código es obligatorio" CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="mb-3">
                                <label for="txtAlias" class="form-label">Alias:</label>
                                <asp:TextBox ID="txtAlias" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvAlias" runat="server" ControlToValidate="txtAlias" ErrorMessage="El alias es obligatorio" CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="mb-3">
                                <label for="txtEspecie" class="form-label">Especie:</label>
                                <asp:TextBox ID="txtEspecie" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvEspecie" runat="server" ControlToValidate="txtEspecie" ErrorMessage="La especie es obligatoria" CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="mb-3">
                                <label for="txtColorPelo" class="form-label">Color de pelo:</label>
                                <asp:TextBox ID="txtColorPelo" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvColorPelo" runat="server" ControlToValidate="txtColorPelo" ErrorMessage="El color de pelo es obligatorio" CssClass="text-danger" Display="Dynamic" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="txtRaza" class="form-label">Raza:</label>
                                <asp:TextBox ID="txtRaza" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvRaza" runat="server" ControlToValidate="txtRaza" ErrorMessage="La raza es obligatoria" CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="mb-3">
                                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
                                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="La fecha de nacimiento es obligatoria" CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="mb-3">
                                <label for="txtPesoActual" class="form-label">Peso Actual:</label>
                                <asp:TextBox ID="txtPesoActual" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvPesoActual" runat="server" ControlToValidate="txtPesoActual" ErrorMessage="El peso actual es obligatorio" CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="mb-3">
                                <label for="fileImagen" class="form-label">Imagen:</label>
                                <asp:FileUpload ID="fileImagen" runat="server" type="file" accept="image/*" onchange="previewImage(event, '#imgPreview')" />
                                <asp:RequiredFieldValidator ID="rfvFileImagen" runat="server" ControlToValidate="fileImagen" ErrorMessage="La imagen es obligatoria" CssClass="text-danger" Display="Dynamic" InitialValue="" />
                            </div>
                        </div>
                    </div>
                    <div class="text-center">
                        <img id="imgPreview" style="max-width: 200px; max-height: 200px; display: block; margin: 0 auto;" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnAgregarMascota" runat="server" Text="Añadir" OnClick="btnAgregarMascota_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

      <%--  <script src="script.js"></script>--%>


</asp:Content>
