using System;
using System.Collections.Generic;
using UIKit;

namespace LoginTraining.iOS
{
	public class RolesPicker : UIPickerViewModel
	{
		/// <summary>
		/// The picker data.
		/// </summary>
		private readonly List<Employee> pickerData;

		/// <summary>
		/// The view.
		/// </summary>
		private readonly UIButton view;

		/// <summary>
		/// The view model.
		/// </summary>
		private readonly LoginViewModel viewModel;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:LoginTraining.iOS.Roles"/> class.
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="viewModel">View model.</param>
		public RolesPicker(UIButton view, LoginViewModel viewModel)
		{
			pickerData = new List<Employee>();
			for (int i = 0; i < EmployeeDumpData.data.Count - 1; i++)
			{
				pickerData.Add(EmployeeDumpData.data[i]);
			}
			this.view = view;
			this.viewModel = viewModel;

		}

		/// <summary>
		/// Gets the component count.
		/// </summary>
		/// <returns>The component count.</returns>
		/// <param name="pickerView">Picker view.</param>
		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		/// <summary>
		/// Gets the rows in component.
		/// </summary>
		/// <returns>The rows in component.</returns>
		/// <param name="pickerView">Picker view.</param>
		/// <param name="component">Component.</param>
		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return pickerData.Count;
		}

		/// <summary>
		/// Gets the title.
		/// </summary>
		/// <returns>The title.</returns>
		/// <param name="pickerView">Picker view.</param>
		/// <param name="row">Row.</param>
		/// <param name="component">Component.</param>
		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return pickerData[(int)row].Role;
		}

		/// <summary>
		/// Selected the specified pickerView, row and component.
		/// </summary>
		/// <returns>The selected.</returns>
		/// <param name="pickerView">Picker view.</param>
		/// <param name="row">Row.</param>
		/// <param name="component">Component.</param>
		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			view.SetTitle(pickerData[(int)row].Role, UIControlState.Normal);
			viewModel.SelectedRoleIndex = row;
			pickerView.Hidden = !pickerView.Hidden;
		}
	}
}
