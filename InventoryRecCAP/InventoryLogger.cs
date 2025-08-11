using InventoryRecCAP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryRecCAP
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log;
        private string _filePath;

        public InventoryLogger(string filePath)
        {
            _log = new List<T>();
            _filePath = filePath;
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");

            _log.Add(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(_log);
        }

        public void SaveToFile()
        {
            try
            {
                string directory = Path.GetDirectoryName(_filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var writer = new StreamWriter(_filePath))
                {
                    string json = JsonSerializer.Serialize(_log, new JsonSerializerOptions 
                    { 
                        WriteIndented = true 
                    });
                    writer.Write(json);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException($"Access denied to file: {_filePath}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Error writing to file: {_filePath}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Unexpected error saving to file: {_filePath}", ex);
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    _log.Clear();
                    return;
                }

                using (var reader = new StreamReader(_filePath))
                {
                    string json = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        _log.Clear();
                        return;
                    }

                    var items = JsonSerializer.Deserialize<List<T>>(json);
                    _log = items ?? new List<T>();
                }
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Error parsing JSON from file: {_filePath}", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException($"Access denied to file: {_filePath}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Error reading from file: {_filePath}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Unexpected error loading from file: {_filePath}", ex);
            }
        }

        public void Clear()
        {
            _log.Clear();
        }

        public int Count => _log.Count;
    }
}
