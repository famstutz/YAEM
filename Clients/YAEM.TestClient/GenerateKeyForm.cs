// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenerateKeyForm.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.TestClient
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The generate key form.
    /// </summary>
    public partial class GenerateKeyForm : Form
    {
        /// <summary>
        /// The key.
        /// </summary>
        private string key;
        
        /// <summary>
        /// Initialises a new instance of the <see cref="GenerateKeyForm"/> class.
        /// </summary>
        public GenerateKeyForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key
        {
            get
            {
                return this.key;
            }

            set
            {
                this.key = value;
                this.KeyTextBox.Text = this.key;
            }
        }

        /// <summary>
        /// Uses the key button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UseKeyButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Generates the key form load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GenerateKeyFormLoad(object sender, EventArgs e)
        {
            this.Key = this.GenerateRandomString(12);
        }

        /// <summary>
        /// Keys the text box text changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void KeyTextBoxTextChanged(object sender, EventArgs e)
        {
            this.Key = this.KeyTextBox.Text;
        }

        /// <summary>
        /// Generates the random string.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>A random generated string.</returns>
        private string GenerateRandomString(int length)
        { 
            var random = new Random();
            var randomString = string.Empty;

            for (int i = 0; i < length; i++)
            {
                int randNumber = random.Next(1, 3) == 1 ? random.Next(97, 123) : random.Next(48, 58);
                randomString = randomString + (char)randNumber;
            }

            return randomString;
        }
    }
}
