﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Kermalis.PokemonBattleEngineClient.Views
{
    public sealed class BattleView : UserControl
    {
        public FieldView Field { get; }
        public ActionsView Actions { get; }
        private readonly MessageView _messages;

        internal BattleClient Client { get; }

        public BattleView()
        {
            // This constructor only exists so xaml compiles
            AvaloniaXamlLoader.Load(this);
        }
        internal BattleView(BattleClient client)
        {
            AvaloniaXamlLoader.Load(this);

            Client = client;
            Field = this.FindControl<FieldView>("Field");
            Field.SetBattleView(this);
            Actions = this.FindControl<ActionsView>("Actions");
            Actions.BattleView = this;
            _messages = this.FindControl<MessageView>("Messages"); // Messages will be null
        }

        internal void AddMessage(string message, bool messageBox = true, bool messageLog = true)
        {
            if (messageBox)
            {
                Field.SetMessage(message);
            }
            if (messageLog)
            {
                _messages.AddMessage(message);
            }
        }
    }
}
