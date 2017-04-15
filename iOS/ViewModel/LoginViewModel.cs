using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace LoginTraining.iOS
{
	public class LoginViewModel : ReactiveObject
	{
		/// <summary>
		/// The name of the role.
		/// </summary>
		private string roleName;
		/// <summary>
		/// The passcode.
		/// </summary>
		private string passcode;
		/// <summary>
		/// The index of the selected role.
		/// </summary>
		private nint selectedRoleIndex = 0;
		/// <summary>
		/// Logins the async.
		/// </summary>
		/// <returns>The async.</returns>
		private IObservable<bool> LoginAsync() => Observable.Return(EmployeeDumpData.data.Exists(u => u.Role == RoleName && u.Passcode == Passcode));
		/// <summary>
		/// The login command.
		/// </summary>
		private readonly ReactiveCommand<Unit, bool> loginCommand;
		/// <summary>
		/// The reset command.
		/// </summary>
		private readonly ReactiveCommand<Unit, Unit> clearCommand;
		/// <summary>
		/// The update command.
		/// </summary>
		private readonly ReactiveCommand<string, Unit> addPadKeyCommand;
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LoginTraining.iOS.LoginViewModel"/> class.
		/// </summary>
		public LoginViewModel()
		{
			var canLogin = this.WhenAnyValue(x => x.Passcode, (p) => !string.IsNullOrEmpty(p));

			this.loginCommand = ReactiveCommand.CreateFromObservable(this.LoginAsync, canLogin);
            this.clearCommand = ReactiveCommand.Create(() =>
			{
				RoleName = null;
				Passcode = null;
			});

			addPadKeyCommand = ReactiveCommand.Create<string>((param) =>
			{
				Passcode += param;
				Console.Write($"Bind {Passcode}");
			});
		}

		/// <summary>
		/// Gets the login command.
		/// </summary>
		/// <value>The login command.</value>
		public ReactiveCommand<Unit, bool> LoginCommand => this.loginCommand;
		/// <summary>
		/// Gets the reset command.
		/// </summary>
		/// <value>The reset command.</value>
		public ReactiveCommand<Unit, Unit> ResetCommand => this.clearCommand;
		/// <summary>
		/// Gets the update command.
		/// </summary>
		/// <value>The update command.</value>
		public ReactiveCommand<string, Unit> UpdateCommand => this.addPadKeyCommand;

		/// <summary>
		/// Gets or sets the name of the role.
		/// </summary>
		/// <value>The name of the role.</value>
		public string RoleName
		{
			get { return roleName; }
			set { this.RaiseAndSetIfChanged(ref roleName, value); }
		}

		/// <summary>
		/// Gets or sets the index of the selected role.
		/// </summary>
		/// <value>The index of the selected role.</value>
		public nint SelectedRoleIndex
		{
			get { return selectedRoleIndex; }
			set { this.RaiseAndSetIfChanged(ref selectedRoleIndex, value); }
		}

		/// <summary>
		/// Gets or sets the passcode.
		/// </summary>
		/// <value>The passcode.</value>
		public string Passcode
		{
			get { return passcode; }
			set { this.RaiseAndSetIfChanged(ref passcode, value); }
		}
	}
}
