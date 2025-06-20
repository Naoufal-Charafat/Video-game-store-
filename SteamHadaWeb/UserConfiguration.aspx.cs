using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
	public partial class UserConfiguration : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["correo"] != null)
			{
				if (!IsPostBack)
				{
					actualEmail.Text = Session["correo"].ToString(); //propiedades comunes de todos los tipos de usuario
					userName.Text = Session["nombre"].ToString();
					userSurname.Text = Session["Apellido"].ToString();
					newPhoneNumber.Text = Session["telefono"].ToString();
					updateEmail.Text = "";
					biography.Text = Session["biografia"].ToString();
					profileImage.ImageUrl = Session["rutaImagen"].ToString();
					maxBiographyLength.Text = biography.MaxLength.ToString() + " caracteres permitidos.";
					biography.Attributes.Add("maxlength", biography.MaxLength.ToString()); //añadimos máximo de caracteres a la biografía
					RegularExpressionEmail.Visible = true;
					validatePhoneNumber.Visible = true;
				}

			}
			else
				Response.Redirect("index.aspx");
		}

		protected void saveChanges_Click(object sender, EventArgs e)
		{
			Usuario originalUser = new Usuario(Session["correo"].ToString(), Session["contrasena"].ToString()); //original
			Usuario destUser = new Usuario(Session["correo"].ToString(), Session["contrasena"].ToString()); //nuevo

			if (newEmail.Text != "")
				destUser.Correo = newEmail.Text;
			else
				destUser.Correo = originalUser.Correo;

			destUser.Nombre = userName.Text;
			destUser.Apellidos = userSurname.Text;

			if (validatePhoneNumber.IsValid)
				destUser.Telefono = newPhoneNumber.Text;
			else
			{
				validatePhoneNumber.ErrorMessage = "Teléfono no válido";
				destUser.Telefono = originalUser.Telefono;
			}
			destUser.Biografia = biography.Text;

			bool emailUpdated = false;

			//originalUser.updateProfile(destUser, emailUpdated);

			updateEmail.Visible = true;

			if (!emailUpdated)
			{
				updateEmail.Text = "El email introducido ya existe";
			}
			else
				updateEmail.Text = "El email fue cambiado correctamente";

			Response.Redirect("UserConfiguration.aspx");
		}

		protected void changeProfilePicture(object sender, EventArgs e)
		{

			//if (int.Parse(Session["privilegio"].ToString()) == 0)
			//ENCliente cliente = new ENCliente(Session["correo"].ToString(), Session["contrasena"].ToString());

			Usuario usu = new Usuario(Session["correo"].ToString(), Session["contrasena"].ToString());

			Random rnd = new Random();
			string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			StringBuilder builder = new StringBuilder(20);
			for (int i = 0; i < 20; i++)
			{
				builder.Append(characters[rnd.Next(characters.Length)]);
			}
			String nombre = builder.ToString();
			String rutaRelativa = "imagenes\\" + nombre + ".png";
			nombre = AppDomain.CurrentDomain.BaseDirectory + "\\imagenes\\" + nombre + ".png";
			ProfilePicUpload.SaveAs(nombre);

			if (usu.updateProfilePic(usu, rutaRelativa)) //si se ha podido actualizar, metemos la imagen
			{
				profileImage.ImageUrl = rutaRelativa;
			}

			changeImage.Text = "Se ha cambiado la imagen correctamtente";
		}

		protected void changePassword_Click(object sender, EventArgs e)
		{
			//compareRepeatedPassword.ErrorMessage = "";
			changedPassword.Text = "";
			Usuario user = new Usuario(Session["correo"].ToString(), Session["contrasena"].ToString()); //original

			if (compareRepeatedPassword.IsValid && newPassword.Text != "" && newRepeatedPassword.Text != "")
			{
				user.Contrasenya = newPassword.Text;
				if (user.changePassword(user))
					changedPassword.Text = "La contraseña se cambió correctamente";
			}
			else
				compareRepeatedPassword.ErrorMessage = "No se cambiaron las contraseñas";

		}

		protected void cancelChanges_Click(object sender, EventArgs e)
		{
			Response.Redirect("UserConfiguration.aspx");
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Redirect("UserConfiguration.aspx");
		}

		protected void updateEmailButton_Click(object sender, EventArgs e)
		{
			if (newEmail.Text != "")
			{
				//RegularExpressionEmail.Visible = true;
				Usuario user = new Usuario(Session["correo"].ToString(), Session["contrasena"].ToString()); //original

				String email = newEmail.Text.ToString();
				updateEmailLabel.Visible = true;

				if (RegularExpressionEmail.IsValid)
				{
					if (user.updateEmail(user, email))
						updateEmailLabel.Text = "El correo se cambió correctamente";
				}
			}
			else
				updateEmail.Text = "El correo no puede ser vacío";

		}

		protected void saveChanges_Click1(object sender, EventArgs e)
		{
			validatePhoneNumber.Visible = true;

			if (validatePhoneNumber.IsValid)
			{
				//actualizar los datos del usuario (Nombre, Apellidos, número de teléfono y biografía (NO TIENEN REQUISITOS MÍNIMOS)
				Usuario user = new Usuario(Session["correo"].ToString(), Session["contrasena"].ToString()); //original

				user.Nombre = userName.Text.ToString();
				user.Apellidos = userSurname.Text.ToString();
				user.Biografia = biography.Text.ToString();
				user.Telefono = newPhoneNumber.Text.ToString();
				user.Correo = Session["correo"].ToString();

				if (user.updateProfile(user))
				{
					changesLabel.Text = "Se han actualizado correctamente los datos";
				}
				else
					changesLabel.Text = "No se ha podido actualizar";
			}
			else
				changesLabel.Text = "Los datos no tienen el formato correcto";
		}

	}
}