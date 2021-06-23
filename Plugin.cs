using System;
using Dalamud.Plugin;
using DalamudPluginProjectTemplate.Attributes;
using ImGuiNET;
using ImGuiScene;
using Dalamud.Configuration;
using Num = System.Numerics;
using Dalamud.Game.Command;
using Dalamud.Interface;
using Dalamud.Game.ClientState.Actors;
using Dalamud.Game.ClientState.Actors.Types;

namespace DalamudPluginProjectTemplate
{
    public class Plugin : IDalamudPlugin
    {
        private DalamudPluginInterface pluginInterface;
        private PluginCommandManager<Plugin> commandManager;
        private Configuration configuration;
        private PluginUI ui;


        private bool enabled;
        private bool config;
        private int gridindex = 0; //Three values, 0 for round, 1 for hexagonal, 3 for square.
        private string[] gridtypes = { "Circular", "Hexagonal", "Square" };


        public string Name => "ArenaPlus";

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.pluginInterface = pluginInterface;

            this.configuration = (Configuration)this.pluginInterface.GetPluginConfig() ?? new Configuration();
            this.configuration.Initialize(this.pluginInterface);

            this.ui = new PluginUI();
            this.pluginInterface.UiBuilder.OnBuildUi += this.ui.Draw;

            this.commandManager = new PluginCommandManager<Plugin>(this, this.pluginInterface);

        }

        [Command("/ArenaPlus")]
        [HelpMessage("Opens configuration for ArenaPlus.")]
        public void OpenMenu(string command, string args)
        {
            var chat = this.pluginInterface.Framework.Gui.Chat;
            var world = this.pluginInterface.ClientState.LocalPlayer.CurrentWorld.GameData;
            chat.Print($"Hello {world.Name}!");
            PluginLog.Log("Message sent successfully.");
        }
        
        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            this.commandManager.Dispose();

            this.pluginInterface.SavePluginConfig(this.config);

            this.pluginInterface.UiBuilder.OnBuildUi -= this.ui.Draw;

            this.pluginInterface.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        private void drawwindow()
        {
            if (config)
            {
                ImGui.SetNextWindowSize(new Num.Vector2(300, 500), ImGuiCond.FirstUseEver);
                ImGuiHelpers.ForceNextWindowMainViewport();
                ImGui.Begin("ArenaPlus Configuration", ref config);

                ImGui.Checkbox("Enable Grid?", ref enabled);
                ImGui.Separator();

                ImGui.ListBox("Grid Type", ref gridindex, gridtypes, 3);
            }
        }
    }
}
